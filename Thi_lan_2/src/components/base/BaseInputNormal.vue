<template>
<div :style="styleInput" :title="[title]">
    <div  v-if="label" class="m-label">
        <div>{{label}}</div>&nbsp;
        <div v-if="isRequire" style="color:red;">*</div>
    </div>
    <input v-if="typeInput == 'input'"
        :type="[isNumber?'number':'text']" class="m-input" 
        :class=" [
            hasIcon?'m-input-icon':'', readOnly?'m-input-readOnly':'', errorInput? 'm-border-red':'',
            isNumber?'m-input-number':''
            ] " 
        :placeholder="[[placeholder]]"  
        :value="value" @input="onInput"
        :readonly="readOnly"
        ref="input"
    >
    <textarea v-else-if="typeInput == 'textarea' "
        type="text" class="m-input m-input-textarea"
        :class=" [hasIcon?'m-input-icon':'', readOnly?'m-input-readOnly':'', errorInput? 'm-border-red':''] " 
        :placeholder="[[placeholder]]" 
        :value="value" @input="onInput"
        :readonly="readOnly"
        :style="styleTextArea"
        ref="input"
        style="resize: none;"
    />
    <div v-if="typeInput == 'date'">
        <v-date-picker :value="value" color="green" :max-date='maxDate' :masks="masks">
            <template v-slot="{ inputValue, inputEvents ,togglePopover }">
                <div class="m-form-date"  :class="[readOnly?'m-input-readOnly':'']">
                    <input type="text" class="m-title-date" placeholder="DD/MM/YYYY" :value="inputValue" v-on="inputEvents" :readonly="readOnly"  :disabled="readOnly">
                    <div class="m-icon-date">
                        <BaseButtonIcon iconClass="btn-calendar" :isSize16="true" @btnClick="togglePopover()"  :readOnly="readOnly"/>
                    </div>
                </div>
            </template>
        </v-date-picker>
    </div>
</div>
</template>

<script>
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
export default {
    components:{
        BaseButtonIcon
    },
    props: {
        label:{
            default:null,
            type:String
        },
        placeholder: String,
        title: String,
        isRequire: { //Xem trường có bắt buộc có hay không
            default: false,
            type: Boolean
        },
        value: [String,Number,Date], //Mặc định nó là như vậy thay bằng tên là gì cũng được VD:(giatri, valusessssss ) ,  nó sẽ :value sẽ map với v-model ở bên ngoài
        hasIcon: { //Mặc định không có icon 
            default: false,
            type: Boolean
        },
        readOnly:{
            default:false,
            type:Boolean
        },
        errorInput:{//Mặc định là không có lỗi
            default:false,
            type:Boolean
        },
        typeInput:{
            type:String,
            required:true
        },
        isNumber:{//Mặc định nó không phải là number
            default:false,
            type:Boolean
        },
        styleInput:
        {   default:'',
            type:String, // Thêm style nếu muốn
        },
        styleTextArea:{//Muốn thay đổi độ cao của textarea
            default:'',
            type:String
        },
        maxDate:{//Nếu kiểu ngày muốn truyền vào ngày lớn nhất có thể có
            default:null,
            type:[Date,String]
        }
    },
    data() {
        return {
            masks: {
                input: 'DD/MM/YYYY', //Dạng format của kiểu date
            },
        }
    },
    
    methods: {
        /**
         * Thực hiện khi thay đổi giá trị trong ô Input
         * CreatedBy: HoaiPT(25/02/2022)
         * UpdateBy: HoaiPT(27/02/2022)
         */
        onInput(event) {
            this.$emit('input', event.target.value) //Mặc định phải tên là 'input' thì nó mới map được với model ở bên ngoài không là nó không map được đâu
        },
        focus: function () {
            this.$refs.input.focus()
        }
        
    },
}
</script>

<style scoped>
@import url('../../style/base/input-normal.css');
</style>
