<template>
<div>
    <div class="m-button-icon" :class="[iconClass]" @click="btnClickButtonIcon" :title="[title]">
    </div>
</div>
</template>

<script>
export default {
    props: {
        iconClass:String,
        title:String
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
