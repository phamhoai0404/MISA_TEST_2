<template>
<div>
    <div class="m-button-icon" :class="[iconClass]" @click="btnClickButtonIcon" :title="[title]">
    </div>
</div>
</template>

<script>
export default {
    props: {
        placeholder: String,
        value: String,
        iconClass:String,
        title:String
    },
    methods: {
        btnClickButtonIcon(){
            this.$emit('btnClick', null);
        }
    },
}
</script>

<style scoped>
@import url('../../style/base/button-icon.css');
</style>
