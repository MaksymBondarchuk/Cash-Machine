//document.onkeypress = onKeyPressed(event);

function onKeyboardNumberClick(value) {
    var id = "Number";
    var screen = $("#" + id)[0];

    if (!screen) {
        id = "Pin";
        screen = $("#" + id)[0];
        if (!screen) {
            id = "requestedAmount";
            screen = $("#" + id)[0];
            screen.value += value;
            return;
        }
        screen.value += value;
        checkSubmitLength(id, screen.value, 4);
        return;
    }

    if (screen.value.length === 4 || screen.value.length === 9 || screen.value.length === 14)
        screen.value += "-";

    screen.value += value;

    checkSubmitLength(id, screen.value, 19);
}

function checkSubmitLength(id, value, length) {
    var screen = $("#" + id)[0];
    if (value.length === length) {
        screen.style.color = "white";   // User won't see encrypted password
        screen.value = window.btoa(value);
        $("#Ok")[0].click();
    }
}

function onKeyboardClearClick() {
    var screen = $("#Number")[0];
    if (!screen)
        screen = $("#Pin")[0];
    if (!screen)
        screen = $("#requestedAmount")[0];
    if (screen)
        screen.value = "";
}

function onKeyPressed(event) {
    var keyValue = event.key;
    if (!isNaN(keyValue))
        onKeyboardNumberClick(keyValue);
}
