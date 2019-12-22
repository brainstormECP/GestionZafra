/// <reference path="jquery-1.7.1.js" />
/// <reference path="jquery.validate-vsdoc.js" />
/// <reference path="jquery.validate.unobtrusive.js" />

jQuery.validator.addMethod("mayor", function (value, element, param) {
    if (value == "") {
        return true;
    }
    return Date.parse(value) >= Date.parse($(param).val());
});

jQuery.validator.unobtrusive.adapters.add("mayor", ["otro"], function(options) {
    options.rules["mayor"] = "#" + options.params.otro;
    options.messages["mayor"] = options.message;
});