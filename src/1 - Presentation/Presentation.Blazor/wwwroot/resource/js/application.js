function focusById(elementId) {
    setTimeout(() => {
        var element = document.getElementById(elementId);
        if (element) {
            element.focus();
        }
    }, 800);
}