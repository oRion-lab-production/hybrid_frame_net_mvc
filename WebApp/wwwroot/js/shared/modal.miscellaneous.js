// modal - miscellaneuos

//Mixin modal
var miscModalApp_vueMixin = {
    data() {
        return {
            defaultModal_id: 'default_app_modal'
        }
    },
    methods: {

    },
    created: function () {
        var self = this;
    },
    mounted: function () {
        var self = this;

        $(document).on('hidden.bs.modal', self.defaultModal_id.$idIndicator, function () {
            var $this = this;

            if ($($this).length != 0)
                $($this).remove();
        });
    }
};

//default global modal
var defaultModal = {
    id: miscModalApp_vueMixin.data().defaultModal_id,
    modalBackDropClass: "modal-backdrop",
    size: {
        small: 'modal-sm',
        large: 'modal-lg',
        xLarge: 'modal-xl'
    }, $call: function (content, size) {
        var self = this, modalId = self.id.$idIndicator();

        size = (function () {
            if (size)
                Object.keys(self.size).forEach(function (key) {
                    if (self.size[key] === size)
                        return size;
                });

            return null;
        })();

        if (content) {
            if ($(modalId).length) {
                console.log(Object.values(self.size));
                if (size == null) {
                    $(modalId).find('.modal-dialog').removeClass(Object.values(self.size));
                } else {
                    if (!$(modalId).hasClass(size))
                        $(modalId).find('.modal-dialog').removeClass(Object.values(self.size)).addClass(size);
                }

                $(modalId).find('.modal-dialog').html(content);
            } else {
                $('<div/>', {
                    class: 'modal fade',
                    id: self.id
                }).append($('<div/>', {
                    class: 'modal-dialog' + (size == null ? "" : " " + size),
                    html: content
                })).appendTo(defaultEl_vue);
            }

            $(modalId).modal({ backdrop: "static" });
        }
    }, $remove: function () {
        var self = this, modalId = self.id.$idIndicator();

        if ($(modalId).length) {
            $(modalId).modal('hide').remove();
            $(self.modalBackDropClass.$classIndicator()).remove();
        } 
    }
};