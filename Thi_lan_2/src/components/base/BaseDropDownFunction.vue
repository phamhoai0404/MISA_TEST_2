<template>
<div class="m-function-group" :style="{ right: positionRight +'px', top: positionTop +'px' }" v-click-outside="hideFunction">
    <div class="m-function-item" v-if="remove" @click="btnRemove">Xóa</div>
    <div class="m-function-item" v-if="edit" @click="btnEdit">Sửa</div>
    <div class="m-function-item" v-if="duplicate" @click="btnDuplicate">Nhân bản</div>
</div>
</template>

<script>
export default {
    props: {
        duplicate: { //Mặc định là không có nút nhân bản
            default: false,
            type: Boolean,
        },
        remove: { //Mặc định là không có nút xóa
            default: false,
            type: Boolean,
        },
        edit: { //Mặc định là không có nút sửa
            default: false,
            type: Boolean,
        },
        positionRight: {
            default: 0,
            type: Number
        },
        positionTop: {
            default: 0,
            type: Number
        }

    },
    methods: {
        /**
         * Thực hiện khi click vào nút Xóa
         * CreatedBy: HoaiPT(25/02/2022)
         */
        btnRemove() {
            var me = this;
            me.$emit('btnRemove');
        },
        /**
         * Thực hiện khi click vào nút Sửa
         * CreatedBy: HoaiPT(25/02/2022)
         */
        btnEdit() {
            var me = this;
            me.$emit('btnEdit');
        },
        /**
         * Thực hiện khi click vào nút Nhân bản
         * CreatedBy: HoaiPT(25/02/2022)
         */
        btnDuplicate() {
            var me = this;
            me.$emit('btnDuplicate');
        },
        /**
         * Thực hiện khi click vào cái bất kì ngoài function này kể cả con thì cũng thực hiện
         * CreatedBy: HoaiPT(25/02/2022)
         */
        hideFunction() {
            var me = this;
            me.$emit('hideFunction');
        }
    }
}
</script>

<style scoped>
@import url('../../style/base/dropdown-function.css');
</style>
