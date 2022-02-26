<template>
<div>
    <div class="m-button-icon" 
        :class="[iconClass]" 
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
        iconClass:String,//Icon mà mong muốn có được
        title:String,//Chữ hiện lên khi hover
        shortKey:String//Phím tắt
    },
    methods: {
         /**
         * Thực hiện khi click vào nút button  icon này
         * CreatedBy: HoaiPT(25/02/2022)
         */
        btnClickButtonIcon(){
            this.$emit('btnClick', null);
        }
    },
}
</script>

<style scoped>
@import url('../../style/base/button-icon.css');
</style>
