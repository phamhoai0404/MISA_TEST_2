<template>
<div>
    <div class="m-checkbox" >
        <input type="checkbox" :id="id" @click="clickCheckbox(id)"/>
        <label :for="id" :style="{fontFamily: fontFamily}"><span></span>{{label}}</label>
    </div>
</div>
</template>

<script>
export default {
    /**
     * Truyền từ cha vào con
     * CreatedBy: HoaiPT(26/02/2022)
     */
    props: {
        id: { //Xác định id
            default: '',
            type: String,
        },
        label: String,
        fontFamily:{
            default:"Notosans",
            type:String,
        },
        valueReal:String
    },
    methods: {
        /**
         * Thực hiện khi click vào checkbox
         * CreatedBy: HoaiPT(26/02/2022)
         */
        clickCheckbox(id){
            var me = this;
            me.$emit('clickCheckbox',{ id: id });
        }       
    },
}
</script>

<style scoped>
@import url(../../style/base/general/checkbox.css);
</style>
