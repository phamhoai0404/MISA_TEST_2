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
            <paginate v-model="pageAction" :page-count="totalPage" :page-range="3" :margin-pages="1" :click-handler="clickCallback" :prev-text="'Trước'" :next-text="'Sau'" :container-class="'m-page-number'" :page-class="'m-page-item'">
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
            totalRecord: 10,
            isShowPage: true,
            pageAction: 2,
            totalPage: 10,
            listPageText: mylib.data.listPageSize,
            selectTextPage:50,
        }
    },
    computed: {
        pageTextInInput: function () {
            return this.selectTextPage + mylib.resourcs["VI"].titlePage;
        }
    },
    methods: {
        clickCallback(number) {
            console.log(number);
        },
        selectedPageText(number) {
            console.log(number);
        }
    }
}
</script>

<style scoped>
@import url('../../style/base/table-paging.css');
</style>
