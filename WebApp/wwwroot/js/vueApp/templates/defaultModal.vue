<template>
    <div :id="defaultModal_id" class="modal fade">
        <div class="modal-dialog {{ defaultModalSize }}">
            {{ defaultModalContent }}
        </div>
    </div>
</template>

<script>

    export default {
        data: function () {
            return {
                defaultModal_id = 'default_app_modal'
            }
        },
        methods: {
            $removeDefaultModal: function () {
                var self = this;

                $('#' + self.defaultModal_id).modal('hide').remove();
            }
        }
    };

</script>