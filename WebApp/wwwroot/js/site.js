// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// default app id $el
var defaultEl_vue = '#app';

Vue.mixin({
    data: function () {
        return {
        }
    },
    methods: {},
    mounted: function () {
    }
});

// global vue mixin
//Vue.mixin({
//    data: function () {
//        return {
//            defaultModal_id: 'default_app_modal',
//            replaceBtnLoading_border: 'border',
//            replaceBtnLoading_grow: 'grow'
//        };
//    },
//    methods: {
//        //$replaceBtnLoading: function (target, type) {
//        //    var self = this, btnLoadingClass = 'spinner-grow';

//        //    if (type == undefined || type == null || type == '')
//        //        throw 'type replace btn Loading undefined';
//        //    else
//        //        if (type == self.replaceBtnLoading_border)
//        //            btnLoadingClass += ' ' + 'spinner-' + self.replaceBtnLoading_grow + '-sm';
//        //        else if (type == self.replaceBtnLoading_grow)
//        //            btnLoadingClass += ' ' + 'spinner-' + self.replaceBtnLoading_grow + '-sm';

//        //    $(target).attr('disabled', 'disabled').html($('<span/>', { class: btnLoadingClass }));
//        //},
//        //$overlayLoadingState: function (target) {
//        //    if ($(target).find('.overlay').length != 0)
//        //        if (!$(target).find('.overlay').is(':visible'))
//        //            $(target).find('.overlay').show();
//        //        else

//        //},
//        $defaultModal: function (content, size) {
//            var self = this;

//            if (content != undefined && content != null && content != '') {

//                if ($('#' + self.defaultModal_id).length != 0) {
//                    if (size != undefined || size != null || size != '') {
//                        if (!$('#' + self.defaultModal_id).find('.modal-dialog').hasClass(size)) {
//                            $('#' + self.defaultModal_id).find('.modal-dialog')
//                                .removeClass(['modal-sm', 'modal-lg', 'modal-xl']).addClass(size);
//                        }
//                    } else {
//                        $('#' + self.defaultModal_id).find('.modal-dialog')
//                            .removeClass(['modal-sm', 'modal-lg', 'modal-xl']);
//                    }

//                    $('#' + self.defaultModal_id).find('.modal-dialog').html(content);
//                } else {
//                    var modalSize = size == undefined || size == '' || size == null ? '' : ' ' + size;

//                    $('<div/>', {
//                        class: 'modal fade',
//                        id: self.defaultModal_id
//                    }).append($('<div/>', {
//                        class: 'modal-dialog' + modalSize,
//                        html: content
//                    })).appendTo($defaultEl);
//                }

//                $('#' + self.defaultModal_id).modal({ backdrop: "static" });
//            }
//        },
//        $removeDefaultModal: function () {
//            var self = this;

//            if ($('#' + self.defaultModal_id).length != 0)
//                $('#' + self.defaultModal_id).modal('hide').remove();
//        }
//    },
//    created: function () {
//        var self = this;
//    },
//    mounted: function () {
//        var self = this;

//        $(document).on('hidden.bs.modal', "#" + self.defaultModal_id, function () {
//            var $this = this;

//            if ($('#' + self.defaultModal_id).length != 0)
//                $($this).remove();
//        });
//    }
//});