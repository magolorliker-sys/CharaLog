window.downloadFile = function (fileName, mimeType, content) {
    try {
        const blob = new Blob([content], { type: mimeType });
        const url = URL.createObjectURL(blob);
        const a = document.createElement('a');
        a.href = url;
        a.download = fileName;
        // DOM に追加してから click することで、より確実にダウンロードを実行
        document.body.appendChild(a);
        a.click();
        document.body.removeChild(a);
        // 少し遅延させてから URL を解放
        setTimeout(() => URL.revokeObjectURL(url), 100);
    } catch (e) {
        console.error('Download failed:', e);
    }
};
