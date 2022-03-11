<template>
<div>
    <div class="m-button-group" 
        :class="{'m-btn-function': hasBackground}" 
        :style="{ width: width, backgroundColor: backgroundColor }" 
        @click="btnClickButtonFunction" 
        :title="[title]"
        v-shortkey="shortKey" @shortkey="btnClickButtonFunction"
    >
        <div class="m-button-title">{{label}}</div>
        <div class="m-button-icon-dropdown"></div>
    </div>
</div>
</template>

<script>
export default {
    props: {
        title: String,//Title truyền vào
        width: String,//Độ rộng mong muốn của button
        label: String,//Nhãn của button
        backgroundColor: String,//Màu mong muốn nếu muốn thay đổi
        hasBackground: {//Button này có màu mặc định là màu xanh không
            default: false,
            type: Boolean
        },
        shortKey:String,//Phím tắt,
        readOnly:{
            default:false,
            type:Boolean,
        },
    },
    methods: {
        /**
         * Thực hiện khi click vào nút button 
         * CreatedBy: HoaiPT(25/02/2022)
         */
        btnClickButtonFunction() {
            if(!this.readOnly){
                this.$emit('btnClick', null);
            }
           
        }
    },
}
</script>

<style scoped>
@import url('../../style/base/button-function.css');
</style>
