function getInput() {
    var screen = $("#screen")[0];
    return screen.firstChild;
}

function onKeyboardNumberClick(value, submitLength) {
    var input = getInput();

    // Insert dashes
    if (submitLength === 19 && (input.value.length === 4 ||
        input.value.length === 9 || input.value.length === 14))
        input.value += "-";

    input.value += value;

    checkSubmitLength(input.value, submitLength);
}

function checkSubmitLength(value, length) {
    if (value.length === length) {
        $("#Ok")[0].click();
    }
}

function onKeyboardClearClick() {
    var input = getInput();
    input.value = "";
}

function encodeData() {
    var input = getInput();
    input.style.color = "white";   // User won't see encrypted password
    input.value = window.btoa(input.value);
}
