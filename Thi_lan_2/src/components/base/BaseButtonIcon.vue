<template>
<div :style="styleButtonIcon">
    <div class="m-button-icon" 
        :class="[
        iconClass,
        isSize16?'m-icon-size-16':''
        ]" 
        @click="btnClickButtonIcon" 
        :title="[title]"
        v-shortkey="shortKey" @shortkey="btnClickButtonIcon"
    >
    </div>
</div>
</template>

<script>
export default {
    props: {
        iconClass:{
            type:String,//Icon mà mong muốn có được
            required: true//Bắt buộc phải có icon
        },
        title:String,//Chữ hiện lên khi hover
        shortKey:String,//Phím tắt,
        isSize16:{//Mặc định không phải là kích thước là icon 16*16
            default:false,
            type:Boolean
        },
        readOnly:{
            default:false,
            type:Boolean,
        },
        styleButtonIcon:String//Thực hiện truyền vào nếu muốn thêm css,
        
    },
    methods: {
         /**
         * Thực hiện khi click vào nút button  icon này
         * CreatedBy: HoaiPT(25/02/2022)
         */
        btnClickButtonIcon(){
            if(!this.readOnly){
                this.$emit('btnClick', null);
            }
            
        }
    },
}
</script>

<style scoped>
@import url('../../style/base/button-icon.css');
</style>
