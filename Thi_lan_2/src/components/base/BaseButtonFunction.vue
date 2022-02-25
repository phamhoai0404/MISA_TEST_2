<template>
<div>
    <div class="m-button-group" :class="{'m-btn-function': hasBackground}" :style="{ width: width, backgroundColor: backgroundColor }" @click="btnClickButtonFunction" :title="[title]">
        <div class="m-button-title">{{label}}</div>
        <div class="m-button-icon-dropdown" ></div>
    </div>
</div>
</template>

<script>
export default {
    props: {
        placeholder: String,
        value: String,
        iconClass: String,
        title: String,
        width:String,
        label:String,
        backgroundColor:String,
        hasBackground:{
            default:false,
            type:Boolean
        }
    },
    methods: {
        btnClickButtonFunction() {
            this.$emit('btnClick', null);
        }
    },
}
</script>

<style scoped>
@import url('../../style/base/button-function.css');
</style>
