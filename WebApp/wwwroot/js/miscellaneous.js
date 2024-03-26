// miscellaneuos

//selector target indicator
var selectorIndicator = {
    id: '#',
    class: '.'
};

//translate id = "a" -> #a
String.prototype.$idIndicator = function () {
    return selectorIndicator.id + this;
};

//translate class = "a" -> .a
String.prototype.$classIndicator = function () {
    return selectorIndicator.class + this;
};

jQuery.fn.extend({
    fnValidateDynamicContent: function (self = false) {
        var $this = this;

        if (!self) {
            $this = $this.find("form");
        }

        if ($this.length > 0) {
            $this.removeData("validator");
            $this.removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse($this);
            $this.validate().resetForm(); // This line is important and added for client side validation to trigger, without this it didn't fire client side errors.
        }
    }
});