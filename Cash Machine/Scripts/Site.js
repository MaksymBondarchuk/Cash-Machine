//document.onkeypress = onKeyPressed(event);

function onKeyboardNumberClick(value) {
    var screen = $("#Number")[0];

    if (!screen) {
        screen = $("#Password")[0];
        if (!screen)
            return;
        screen.value += value;
        checkSubmitLength(screen.value, 4);
        return;
    }

    if (screen.value.length === 4 || screen.value.length === 9 || screen.value.length === 14)
        screen.value += "-";

    screen.value += value;

    checkSubmitLength(screen.value, 19);
}

function checkSubmitLength(value, length) {
    if (value.length === length)
        $("#Ok")[0].click();
}

function onKeyboardClearClick() {
    var screen = $("#Number")[0];
    screen.value = "";
}

function onKeyPressed(event) {
    var keyValue = event.key;
    if (!isNaN(keyValue))
        onKeyboardNumberClick(keyValue);
}
