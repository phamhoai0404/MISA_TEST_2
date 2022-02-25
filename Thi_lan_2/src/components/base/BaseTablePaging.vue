<template>
<div class="m-table-paging">
    <div class="m-paging-left">
        Tổng số: <b>{{totalRecord}}</b>
        bản ghi
    </div>
    <div class="m-paging-right">
        <div class="m-left">
            <div class="m-combobox" style="width: 200px;" :class="{'selected': isShowPage}">
                <input type="text" :value="pageTextInInput" readOnly>
                <button class="m-button-padding" @click="btnSelectPage()">
                    <div class="m-icon-drown"></div>
                </button>
                <div class="m-combobox-data" v-if="isShowPage">
                    <div v-for="(textPage,index) in listPageText" :key="index" class="m-combobox-item-page" @click='selectedPageText(index)' :class="{'selected': selectTextPage == textPage }">{{ textPage }} bản ghi trên 1 trang</div>
                </div>
            </div>
        </div>
        <div class="m-right">
            <paginate :value="pageAction" :page-count="totalPage" :page-range="3" :margin-pages="1" :click-handler="clickCallback" :prev-text="'Trước'" :next-text="'Sau'" :container-class="'m-page-number'" :page-class="'m-page-item'">
            </paginate>
        </div>
    </div>
</div>
</template>

<script>
import * as mylib from '../../js/resourcs.js'

export default {
    data() {
        return {

        }
    },
    props: {
        totalRecord: { //Tổng số bản ghi ban đầu
            default: 0,
            type: Number
        },
        isShowPage: { //Trạng thái đóng mở của listPage nếu không truyền vào thì mặc định là false
            default: false,
            type: Boolean
        },
        pageAction: { //Trang đang thực hiện hiển thị nếu không truyền vào thì mặc định là 1
            default: 1,
            type: Number
        },
        totalPage: { //Tổng số trang mặc định nếu không truyền vào là 1
            default: 1
        },
        listPageText: Array, //Mảng kích thước trang mong truyền vào
        selectTextPage: { //Nếu không truyền dữ liệu vào thì mặc định là 20 trang
            default: 20
        },
    },
    computed: {
        pageTextInInput: function () {
            return this.selectTextPage + mylib.resourcs["VI"].titlePage;
        }
    },
    methods: {
        clickCallback(number) {
            var me = this;
            me.$emit('clickCallback', { number: number} );
        },
        selectedPageText(index) {
            var me = this;
            me.$emit('selectedPageText', { index: index} );
        },
        btnSelectPage() {
            var me = this;
            me.$emit('btnSelectPage');
        }

    }
}
</script>

<style scoped>
@import url('../../style/base/table-paging.css');
</style>
