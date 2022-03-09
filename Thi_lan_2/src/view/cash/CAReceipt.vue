<template>
    <div class="ac-list-group">
        <div class="ac-list-top" style="padding-bottom: 0px; max-height:50px; padding-top:15px;">
            <div class="top-header-di" >
                <div class="top-title">THU CHI TIỀN MẶT</div>
                <div class="top-right" style="min-width:280px !important;">
                    <div class="group-tour">
                        <BaseButtonIcon iconClass="btn-tour" />
                        <div class="title-tour">Hướng dẫn</div>
                    </div>
                    <BaseButtonFunction label="Thêm chi tiền" :hasBackground="true"  />
                </div>
            </div>
        </div>
        <div class="ac-list-center">
            <BaseOverview />
        </div>
        <div class="ac-list-bottom">
            <div class="ac-list-function">
                <div class="function-left">
                    <div class="icon-check">
                        <BaseButtonIcon iconClass="btn-arrow-check-all" />
                    </div>
                    <BaseButtonFunction label="Thực hiện hàng loạt" />
                    <BaseButtonFunction label="Lọc" />
                </div>
                <div class="function-right">
                    <BaseInput typeInput="input" :hasIcon="true" placeholder="Nhập từ khóa tìm kiếm" />
                    <BaseButtonIcon iconClass="btn-refresh" title="Lấy lại dữ liệu" />
                    <BaseButtonIcon iconClass="btn-excel" title="Xuất ra excel" />
                    <BaseButtonIcon iconClass="btn-setting-background" title="Tùy chỉnh giao diện"/>
                </div>

            </div>
            <div class="ac-list-table">
                 <BaseTableList
                    height="235px"
                    :hasFooterTable="true"
                    :listFields ="listFieldCAPayment"
                    :listData ="listCAPayment"
                    @btnView ='btnSeeInfoCAPayment'
                    @btnDropDown ='btnDropDown'
                    :nameTable="'CaPayment'"
                /> 
                <BaseTablePaging  
                    :isShowPage="isShowPage"
                    @btnSelectPage="btnSelectPage()" 
                    @selectedPageText="selectedPageText"
                    @clickCallback="clickCallback"
                    :listPageText="listPageText"
                    :totalRecord="totalRecord"
                    :pageAction="pageAction"
                    :totalPage="totalPage"
                    :selectTextPage="selectTextPage"

                />
            </div>
        </div>
    </div>
</template>
<script>
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseButtonFunction from '@/components/base/BaseButtonFunction.vue'
import BaseOverview from '@/components/base/BaseOverview.vue'
import BaseInput from '@/components/base/BaseInputNormal.vue'

import BaseTableList from '@/components/base/BaseTableList.vue'
import BaseTablePaging from '@/components/base/BaseTablePaging.vue'

import * as mylib from '../../js/resourcs.js'
export default {
    components:{
        BaseButtonFunction,
        BaseButtonIcon,
        BaseOverview,
        BaseInput,
        BaseTableList,
        BaseTablePaging
    },
    data() {
        return {
            listCAPayment:mylib.dataTest.listCAPayment,
            listFieldCAPayment:mylib.data.listFieldCAPayment,

            isShowPage: false,
            listPageText:mylib.data.listPageSize,
            totalRecord:0,
            pageAction:1,
            totalPage:1,
            selectTextPage: 20,
        }
    },
    methods: {
        btnSeeInfoCAPayment(){},
        btnDropDown(){},
        selectedPageText(){},
        btnSelectPage(){},
        clickCallback(){}
    },
}
</script>