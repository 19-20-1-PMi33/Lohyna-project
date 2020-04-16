$(function () {
    $("#modalHeader").on({
        mousedown: function (e) {
            dragging = true;
            dragX = e.clientX - $(this).position().left;
            dragY = e.clientY - $(this).position().top;
        },
        mouseup: function () { dragging = false; },
        mousemove: function (e) {
            if (dragging)
                $(this).offset({ top: e.clientY - dragY, left: e.clientX - dragX });

        }
    })
})