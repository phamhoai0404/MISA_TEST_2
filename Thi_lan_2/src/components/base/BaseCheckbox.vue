<template>
<div>
    <div class="m-checkbox" :style="styleCheckbox">
        <input type="checkbox" :id="id" @click="clickCheckbox(id)"/>
        <label :for="readOnly==false ? id: '' " :style="{fontFamily: fontFamily}"><span></span>{{label}}</label>
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
        valueReal:String,
        styleCheckbox:{//Trường hợp muốn thêm style cho checkbox
            default:'',
            type:String
        },
        readOnly:{//Có chỉ được đọc hay không
            default:false,//Mặc định là bình thường
            type:Boolean
        }
    },
    methods: {
        /**
         * Thực hiện khi click vào checkbox
         * CreatedBy: HoaiPT(26/02/2022)
         */
        clickCheckbox(id){
            var me = this;
            if( !me.readOnly ){
                me.$emit('clickCheckbox',{ id: id });
            }
            
        }       
    },
}
</script>

<style scoped>
@import url(../../style/base/general/checkbox.css);
</style>
