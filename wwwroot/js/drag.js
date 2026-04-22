console.log('[drag.js] cargado correctamente');

window.dragInterop = {
    startDrag: function (dotnet, startX, startY, winX, winY) {
        console.log('[drag.js] startDrag llamado', startX, startY);

        const onMove = (e) => {
            const dx = e.clientX - startX;
            const dy = e.clientY - startY;
            dotnet.invokeMethodAsync('OnDragMove', winX + dx, winY + dy);
        };

        const onUp = (e) => {
            document.removeEventListener('mousemove', onMove);
            document.removeEventListener('mouseup', onUp);
            const dx = e.clientX - startX;
            const dy = e.clientY - startY;
            dotnet.invokeMethodAsync('OnDragEnd', winX + dx, winY + dy);
        };

        document.addEventListener('mousemove', onMove);
        document.addEventListener('mouseup', onUp);
    }
};