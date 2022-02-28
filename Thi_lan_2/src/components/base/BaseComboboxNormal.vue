<template>
<div :style="styleComboboxNormal">
    <div v-if="label" class="m-label">
        <div>{{label}}</div>&nbsp;
        <div v-if="isRequire" style="color:red;">*</div>
    </div>
    <div class="m-combobox-group" >
        <div class="m-combobox-top" :class=" [ isShowDataDropdown?'m-combobox-border-green':'',errorCombobox? 'm-combobox-border-red':''] ">
            <input class="m-input-combobox"
                :placeholder="[[placeholder]]"  
                :value="value" @input="onInput"
                :ref="refText"
                :readonly="readOnly"
            >
            <div class="m-combobox-icon">
                <div  v-if="isButtonAdd" class="m-button-dropdown" style="border-right:1px solid #bbb;">
                    <BaseButton iconClass="btn-plus-success" :isSize16="true"/>
                </div>
                <div class="m-button-dropdown m-button-final" @click="btnClickDropdown">
                    <BaseButton iconClass="btn-icon-drown" :isSize16="true"/>
                </div>
               
            </div>
        </div>
        <!-- Dùng cho combobox có dữ liệu là table -->
        <div class="m-combobox-data" v-if="isShowDataDropdown && isComboboxTable" >
            <table border="1" class="m-table-combobox">
                <thead>
                    <tr>
                        <td v-for="(field,index) in listFields" :key="index">{{field.text}}</td>
                    </tr>
                </thead>
                <tbody>
                    <tr  v-for="(data,index) in listData" :key="index">
                        <td v-for="(field,i) in listFields" :key="i">{{data[field.name]}}</td>
                    </tr>
                </tbody>
            </table>
        </div>

        <!-- Dùng cho combobox có dữ liệu là bình thường -->
        <div class="m-combobox-data" v-if="isShowDataDropdown && !isComboboxTable" >
            <!-- <div class="m-combobox-item- m-combobox-active">sfsfsf</div>
            <div class="m-combobox-item-">sfsfsf</div>
            <div class="m-combobox-item-">sfsfsf</div>
            <div class="m-combobox-item-">sfsfsf</div>
            <div class="m-combobox-item-">sfsfsf</div> -->
            <div  v-for="(data,index) in listData" :key="index" class="m-combobox-item-" :class="[ data==value?'m-combobox-active':'' ]" >{{data}}</div>
        </div>
    </div>
</div>
</template>

<script>
import BaseButton from '@/components/base/BaseButtonIcon.vue'

export default {
    components:{
        BaseButton
    },
    props: {
        label: {
            default: "xinh gái ",
            type: String
        },
        isRequire: { //Xem trường có bắt buộc có hay không
            default: false,
            type: Boolean
        },
        value: [String,Number],
        refText:String,
        placeholder:String,
        readOnly:{
            default:false,
            type:Boolean
        },
        isButtonAdd:{
            default:false,
            type:Boolean,
        },
        styleComboboxNormal:String,//Trường hợp muốn thêm css gì đó từ cha vào
        styleBorder:{//Mặc định là không border
            default:'',
            type:String
        },
        errorCombobox:{
            default:false,//Mặc định là không có lỗi,
            type:Boolean
        },
        isShowDataDropdown:{
            default:false,//Mặc định là đóng data dropdown
            type:Boolean
        },
        isComboboxTable:{//Mặc định là combobox bình thường
            default:false,
            type:Boolean
        },
        listData:Array//Để thử là array

    },
    methods: {
        /**
         * Thực hiện khi thay đổi giá trị trong ô Input
         * CreatedBy: HoaiPT(28/02/2022)
         */
        onInput(event) {
            this.$emit('input', event.target.value) //Mặc định phải tên là 'input' thì nó mới map được với model ở bên ngoài không là nó không map được đâu
            // this.styleBorder="m-combobox-border-green";
        },
        btnClickDropdown(){
            this.$emit('btnClickDropdown');
        }
    },
}
</script>

<style scoped>
@import url(../../style/base/combobox-normal.css);
</style>
