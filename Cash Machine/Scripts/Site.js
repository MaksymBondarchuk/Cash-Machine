//document.onkeypress = onKeyPressed(event);

function onKeyboardNumberClick(value) {
    var screen = $("#screen")[0];

    if (screen.value.length === 4 || screen.value.length === 9 || screen.value.length === 14)
        screen.value += "-";

    screen.value += value;

    //if (screen.value.length === 19)
    //    $("#CardNumberOk")[0].click();
}

function onKeyboardClearClick() {
    var screen = $("#screen")[0];
    screen.value = "";
}

function onKeyPressed(event) {
    var keyValue = event.key;
    if (!isNaN(keyValue))
        onKeyboardNumberClick(keyValue);
}