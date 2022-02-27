<template>
<div>
    <div  v-if="label" class="m-label">
        <div>{{label}}</div>&nbsp;
        <div v-if="isRequire" style="color:red;">*</div>
    </div>
    <input v-if="typeInput == 'input' "
        :type="[isNumber?'number':'text']" class="m-input" 
        :class=" [
            hasIcon?'m-input-icon':'', readOnly?'m-input-readOnly':'', errorInput? 'm-border-red':'',
            isNumber?'m-input-number':''
            ] " 
        :placeholder="[[placeholder]]" :title="[title]" 
        :value="value" @input="onInput"
        :ref="refText"
        :readonly="readOnly"
    >
    <textarea v-else-if="typeInput == 'textarea' "
        type="text" class="m-input m-input-textarea"
        :class=" [hasIcon?'m-input-icon':'', readOnly?'m-input-readOnly':'', errorInput? 'm-border-red':''] " 
        :placeholder="[[placeholder]]" :title="[title]" 
        :value="value" @input="onInput"
        :ref="refText"
        :readonly="readOnly"
    />
</div>
</template>

<script>
export default {
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
        value: String, //Mặc định nó là như vậy thay bằng tên là gì cũng được VD:(giatri, valusessssss ) ,  nó sẽ :value sẽ map với v-model ở bên ngoài
        hasIcon: { //Mặc định không có icon 
            default: false,
            type: Boolean
        },
        refText:String,
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
        }
    },
}
</script>

<style scoped>
@import url('../../style/base/input-normal.css');
</style>
