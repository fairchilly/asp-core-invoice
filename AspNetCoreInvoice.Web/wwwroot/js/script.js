// Handle new item add
function addRow(type) {
    
    // Copyable rows
    let starterTemplate = $('#starter-' + type).html();
    let count = $('.invoice-' + type).length;

    // Needed to work with asp-for tags
    let upperCaseType = type.charAt(0).toUpperCase() + type.slice(1) + "s";

    // Needed to escape special characters
    RegExp.quote = function(str) {
        return str.replace(/([.?*+^$[\]\\(){}|-])/g, "\\$1");
    };
    
    let regexOne = new RegExp(RegExp.quote(upperCaseType + "_0"),"g");
    let regexTwo = new RegExp(RegExp.quote(upperCaseType + "[0]"),"g");
    let newRow = starterTemplate.replace(regexOne, upperCaseType + "_" + count)
        .replace(regexTwo, upperCaseType + "[" + count + "]");

    $('#invoice-' + type).append(newRow);

    // Needed to activate radio buttons, if required
    $('.ui.radio.checkbox').checkbox();

    showOrHideRemoveButton(type, true);
}

function removeRow(type) {
    let count = $('.invoice-' + type).length;
    let lastItem = $('.invoice-' + type)[count - 1].remove();

    if (count === 2) showOrHideRemoveButton(type, false);
}

function showOrHideRemoveButton(type, show) {
    show ? $('#remove-' + type).show() : $('#remove-' + type).hide();
}

$(function () {
    $('.datepicker').datepicker({ dateFormat: 'MM d, yy' });
    $('.ui.radio.checkbox').checkbox();
    
    $('#generate').click(function () {
        let valid = $('#invoice-form')[0].checkValidity();
        if (valid) {
            let element = $(this);
            element.addClass('loading');
            setTimeout(function(){
                element.removeClass('loading');
            }, 2000);
        }
    });
});

