<template>
<div>
    <div class="m-button-group" :class="{'m-btn-function': hasBackground}" :style="{ width: width, backgroundColor: backgroundColor }" @click="btnClickButtonFunction" :title="[title]">
        <div class="m-button-title">{{label}}</div>
        <div class="m-button-icon-dropdown"></div>
    </div>
</div>
</template>

<script>
export default {
    props: {
        placeholder: String,//Nơi để mặc định
        title: String,//Title truyền vào
        width: String,//Độ rộng mong muốn của button
        label: String,//Nhãn của button
        backgroundColor: String,//Màu mong muốn nếu muốn thay đổi
        hasBackground: {//Button này có màu mặc định là màu xanh không
            default: false,
            type: Boolean
        }
    },
    methods: {
        /**
         * Thực hiện khi click vào nút button 
         * CreatedBy: HoaiPT(25/02/2022)
         */
        btnClickButtonFunction() {
            this.$emit('btnClick', null);
        }
    },
}
</script>

<style scoped>
@import url('../../style/base/button-function.css');
</style>
