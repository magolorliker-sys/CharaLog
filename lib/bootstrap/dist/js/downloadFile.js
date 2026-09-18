window.downloadFile = function (fileName, mimeType, content) {
    try {
        const blob = new Blob([content], { type: mimeType });
        const url = URL.createObjectURL(blob);
        
        // iOS Safari対応
        if (/iPad|iPhone|iPod/.test(navigator.userAgent)) {
            // iOSの場合、別のアプローチを試みる
            const reader = new FileReader();
            reader.onload = function(e) {
                const link = document.createElement('a');
                link.href = e.target.result;
                link.download = fileName;
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
                setTimeout(() => URL.revokeObjectURL(url), 100);
            };
            reader.readAsDataURL(blob);
        } else {
            // その他のブラウザ（Android等）
            const a = document.createElement('a');
            a.href = url;
            a.download = fileName;
            a.style.display = 'none';
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
            setTimeout(() => URL.revokeObjectURL(url), 100);
        }
    } catch (e) {
        console.error('Download failed:', e);
        alert('ダウンロードに失敗しました。もう一度お試しください。');
    }
};
