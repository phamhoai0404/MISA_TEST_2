<template>
<div>
    <div class="m-button-base" 
        :style="{width:width}" 
        :class="{'m-button-background': hasBackground}"
        @click="btnClickButtonBase" 
        :title="[title]"
        v-shortkey="shortKey" @shortkey="btnClickButtonBase"
     >
        <div class="m-button-title">{{label}}</div>
    </div>
</div>
</template>

<script>
export default {
    props: {
        title: String, //Title truyền vào
        width: String, //Độ rộng mong muốn của button
        label: String,
        backgroundColor: String, //Màu mong muốn nếu muốn thay đổi
        hasBackground: { //Button này có màu mặc định là màu xanh không
            default: false,
            type: Boolean
        },
        shortKey:String //Phím tắt
    },
    methods: {
        /**
         * Thực hiện khi click vào nút button 
         * CreatedBy: HoaiPT(26/02/2022)
         */
        btnClickButtonBase() {
            this.$emit('btnClick', null);
        }
    },
}
</script>

<style scoped>
@import url('../../style/base/button-base.css');
</style>
