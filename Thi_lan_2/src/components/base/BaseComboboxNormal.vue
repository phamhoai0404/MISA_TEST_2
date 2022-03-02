<template>
<div :style="styleComboboxNormal" v-click-outside="hideDataDropDown" >
    <div v-if="label" class="m-label">
        <div>{{label}}</div>&nbsp;
        <div v-if="isRequire" style="color:red;">*</div>
    </div>
    <div class="m-combobox-group" >
        <div class="m-combobox-top" :class=" [ isShowDataDropdown?'m-combobox-border-green':'',errorCombobox? 'm-combobox-border-red':'', readOnly?'m-combobox-readOnly':'']">
            <input class="m-input-combobox"
                :placeholder="[[placeholder]]"  
                :value="value" @input="onInput"
                :ref="refText"
                :readonly="readOnly"
            >
            <div class="m-combobox-icon">
                <div  v-if="isButtonAdd" class="m-button-dropdown" style="border-right:1px solid #bbb;" >
                    <BaseButton iconClass="btn-plus-success" :isSize16="true"/>
                </div>
                <div class="m-button-dropdown m-button-final" @click="btnClickDropdown" :class="[isShowDataDropdown? 'm-icon-dropdown-rotation': '']">
                    <BaseButton iconClass="btn-icon-drown" :isSize16="true" />
                </div>
               
            </div>
        </div>
        <!-- Dùng cho combobox có dữ liệu là table -->
        <div class="m-combobox-data table-combo" v-if="isShowDataDropdown && isComboboxTable" :style="styleDataCombobox">
            <table border="1" class="m-table-combobox">
                <thead>
                    <tr>
                        <th v-for="(field,index) in listFields" :key="index"
                            :style="{ 
                                width: field.width,
                                textAlign: field.type =='number'? 'right':''|| field.type =='date'? 'center':''
                            }"
                        
                        >{{field.text}}</th >
                    </tr>
                </thead>
                <tbody>
                    
                    <tr  v-for="(data,index) in listData" :key="index"  class="m-combobox-item-" 
                        :class="[
                           comparisonValue(data[keySearch],propertyCompare)?'m-combobox-active':'',/**Nếu mà bằng với cái ở bên ngoài thì cho màu background */
                           (propertyCompare==null)&&(index==0)? 'm-combobox-active':''/**Nếu không tồn tại giá trị bằng (nó bằng null) và chỉ số nó bằng 0 thì sẽ cho background nó ở đấy */
                        ]" 
                    >
                        <td v-for="(field,i) in listFields" :key="i"
                            :style="field.type =='number'?'text-align:right' : '' || field.type =='date'?'text-align:center' : ''"
                            @click="btnClickItemTable(data)"
                        >
                            <span v-if="field.type == 'date' " >{{data[field.name] | formatDate }}</span>
                            <span v-else >{{data[field.name]}}</span>
                        </td>
                    </tr>
                    <tr v-if="listData.length == 0" class="m-combobox-item- m-combobox-no-item">
                        <td :colspan="listFields.length" >Không có dữ liệu hiển thị</td>
                    </tr>
                </tbody>
            </table>
        </div>

        <!-- Dùng cho combobox có dữ liệu là bình thường -->
        <div class="m-combobox-data" v-if="isShowDataDropdown && !isComboboxTable" >
            <div class="m-combobox-content-data">
                <div  v-for="(data,index) in listData" :key="index" class="m-combobox-item-"
                    :class="[comparisonValue(data,value)?'m-combobox-active':'' ]"
                    @click="btnClickItem(data)"
                >{{data}}</div>
                <div v-if="listData.length == 0" class="m-combobox-item- m-combobox-no-item">Không có dữ liệu hiển thị</div>
            </div>
        </div>
    </div>
</div>
</template>

<script>
import BaseButton from '@/components/base/BaseButtonIcon.vue'
import MyFunction from '@/js/function.js'

export default {
    components:{
        BaseButton
    },
    props: {
        label: {
            default: "",
            type: String
        },
        isRequire: { //Xem trường có bắt buộc có hay không
            default: false,
            type: Boolean
        },
        value: [String,Number,Object],
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
        styleDataCombobox:String,
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
        listData:Array,//Dữ liệu truyền vào,
        listFields:Array, //Truyền fields nếu là là isComboboxTable

        keySearch:String,//Để mục đích css,
        propertyCompare:{},
    },
    methods: {
        /**
         * Thực hiện khi thay đổi giá trị trong ô Input
         * CreatedBy: HoaiPT(28/02/2022)
         */
        onInput(event) {
            this.$emit('input', event.target.value) //Mặc định phải tên là 'input' thì nó mới map được với model ở bên ngoài không là nó không map được đâu
        },
        /**
         * Thực hiện click nút dropdown
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnClickDropdown(){
            if(!this.readOnly){//Nếu mà không có lệnh chỉ đọc thì mới được thực hiện ở bên trong
                this.$emit('btnClickDropdown');
            }
            
        },
        /**
         * Thực hiện click vào một Item bất kỳ
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnClickItem(object){
            this.$emit('btnClickItem',{object:object});
        },
        btnClickItemTable(object){
            this.$emit('btnClickItemTable',{object:object});
        },

        /**
         * Thực hiện khi click bất kì ngoài ô đấy thì nó sẽ đóng lại
         */
        hideDataDropDown(){
            this.$emit('hideDataDropDown');
        },
        comparisonValue:MyFunction.comparisonValue,//import từ file js về
       
    },
     filters: {
        /**
         * Thực hiện định dạng lại ngày
         * CreatedBy: HoaiPT(01/03/2022)
         */
        formatDate:MyFunction.formatDate,
    }
}
</script>

<style scoped>
@import url(../../style/base/combobox-normal.css);
</style>
