// CharaLog: JSONエクスポート用ダウンロードヘルパー
// Blazor 側 (DataSettings.razor) から
//   await JS.InvokeVoidAsync("downloadFile", fileName, mimeType, content)
// として呼び出される。
//
// iOS Safari (特にホーム画面に追加した「スタンドアロン」表示のアプリ) は、
// <a download> やデータURLへのナビゲーションを無視することがあり、その場合
// エラーは出ないままファイルも保存されない、という状態になる。
// これを避けるため、まず Web Share API (navigator.share) でファイルとして
// 共有し、共有シートの「"ファイル"に保存」から保存してもらう方式を優先し、
// 対応していない環境（主にPCのブラウザ）でのみ従来の <a download> 方式に
// フォールバックする。
window.downloadFile = async function (fileName, mimeType, content) {
    const blob = new Blob([content], { type: mimeType });

    // 1) Web Share API (ファイル共有) が使える場合はこちらを優先。
    //    iOSのホーム画面ショートカット/PWAでも動作する。
    try {
        const file = new File([blob], fileName, { type: mimeType });
        if (navigator.canShare && navigator.canShare({ files: [file] })) {
            await navigator.share({ files: [file], title: fileName });
            return;
        }
    } catch (e) {
        if (e && e.name === 'AbortError') {
            // ユーザーが共有シートを自分でキャンセルしただけなので、
            // エラー扱いにはしない。
            return;
        }
        console.warn('navigator.share に失敗したため、従来方式にフォールバックします。', e);
    }

    // 2) フォールバック: Blob URL + <a download>
    const url = URL.createObjectURL(blob);
    try {
        if (/iPad|iPhone|iPod/.test(navigator.userAgent)) {
            await new Promise((resolve, reject) => {
                const reader = new FileReader();
                reader.onerror = () => reject(reader.error || new Error('FileReader failed'));
                reader.onload = function (e) {
                    const link = document.createElement('a');
                    link.href = e.target.result;
                    link.download = fileName;
                    document.body.appendChild(link);
                    link.click();
                    document.body.removeChild(link);
                    resolve();
                };
                reader.readAsDataURL(blob);
            });
        } else {
            const a = document.createElement('a');
            a.href = url;
            a.download = fileName;
            a.style.display = 'none';
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
        }
    } finally {
        setTimeout(() => URL.revokeObjectURL(url), 1000);
    }
};
