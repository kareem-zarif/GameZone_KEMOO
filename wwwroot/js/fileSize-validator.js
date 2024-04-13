//@* Kemo => to add maxfileSize => need to add clientSideValidationMethod not exact in default jquery * @
$.validator.addMethod("MaxFileSizeInBytes", function (value, element, param) {
    var isValid = this.optional(element) || element.files[0].size <= param;
    return isValid;
});