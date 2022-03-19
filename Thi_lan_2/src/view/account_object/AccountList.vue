<template>
<div>
    <div class="ac-list-group">
        <div class="ac-list-top">
            <div class="top-header-di">
                <div class="top-title">DANH SÁCH NHÀ CUNG CẤP</div>
                <div class="top-right">
                    <div class="group-tour">
                        <BaseButtonIcon iconClass="btn-tour" />
                        <div class="title-tour">Hướng dẫn</div>
                    </div>
                    <BaseButtonFunction label="Tiện ích" />
                    <BaseButtonFunction label="Thêm" :hasBackground="true" @btnClick="btnAddAccount" />
                </div>
            </div>
            <div class="top-header-bottom">
                <BaseButtonIcon iconClass="btn-chevron-left" :isSize16="true" />
                <a>Tất cả danh mục</a>
            </div>
        </div>
        <div class="ac-list-center">
            <BaseOverview />
        </div>
        <div class="ac-list-bottom">
            <div class="ac-list-function">
                <div class="function-left" >
                    <div class="icon-check">
                        <BaseButtonIcon iconClass="btn-arrow-check-all" />
                    </div>
                    <BaseButtonFunction label="Thực hiện hàng loạt" styleButton="max-width: 183px !important;min-width: 183px !important" @btnClick="isShowRemoveMany = !isShowRemoveMany"/>
                    <div v-if="listAccountObjectRemove.length >0 && isShowRemoveMany == true" class="delete-many">
                        <div @click="btnRemoveMany">Xóa</div> 
                    </div>
                    <BaseButtonFunction label="Lọc" styleButton='margin-left:10px; margin-right: 10px; width: 78px !important;' @btnClick="btnClickFilterList"/>
                    <div class="group-filter">
                        <div v-for="(item, index) in objectFilter " :key="index" class="item-filter" >
                            <span v-if="item != null && item !='' ">
                                <div class="item-title" >{{item}} </div>
                                <BaseButtonIcon iconClass="btn-close-small" :isSize16="true" styleButtonIcon="margin-left:3px;" @btnClick="btnClickRemoveInItemFilter(item,index)"/>
                            </span>
                        </div>
                        <div  v-if="exitObjectFilter()" class="item-filter" >
                            <span>
                                <div class="item-title" @click="btnRemoveAllFilter" >Xóa bộ lọc</div>
                                <BaseButtonIcon iconClass="btn-close-small" :isSize16="true" styleButtonIcon="margin-left:3px;" @btnClick="btnRemoveAllFilter"/>
                            </span>
                        </div>
                    </div>
                    <div class="dropdown-filter" style="margin-top: 333px;" v-if="isShowFilterAccountObject" >
                        <div class="row-two">
                            <div style="width: 49.5%">
                                <BaseComboboxNormal v-model="objectFilterTemp.Type" label="Loại" :datas="[]" title="Loại"/>
                            </div>
                            <div style="width: 49.5%">
                                <BaseComboboxNormal label="Nhóm" styleDataCombobox="width: 460px;"
                                    :isComboboxTable="true"
                                    v-model="objectFilterTemp.AccountObjectGroupCode"
                                    :errorCombobox="errorAccountObjectGroup"
                                    :title="titleAccountObjectGroup"

                                    :listFields="listFieldAccountObjectGroup"
                                    :datas="listAccountObjectGroup"

                                    inputText="AccountObjectGroupCode"
                                    :propertyCompare="objectFilterTemp.AccountObjectGroupId"
                                    keySearch="AccountObjectGroupId"

                                    @onChangeValueKeySearch ="changeIdAccountObjectGroup"
                                    @input="changeInputAccountObjectGroup"

                                    ref="AccountObjectGroup"
                                />
                            </div>
                        </div>
                        <div class="row-two" style="padding-top: 10px;">
                            <div style="width: 49.5%">
                                <BaseComboboxNormal v-model="objectFilterTemp.Type" label="Tình trạng công nợ" :datas="[]" title="Tình trạng công nợ" />
                            </div>
                            <div style="width: 49.5%">
                                <BaseComboboxNormal v-model="objectFilterTemp.Type" label="Trạng thái" :datas="[]" title="Trạng thái"/>
                            </div>
                        </div>
                        <div class="row-two" style="padding-top: 10px;">
                            <div style="width: 32.5%">
                                <BaseComboboxNormal label="Tỉnh/TP"
                                    v-model="objectFilterTemp.ProvinceOrCity"
                                    :isComboboxTable="true" :showField ="false"

                                    :errorCombobox="errorProvinceOrCity"
                                    :title="titleProvinceOrCity"
                                    :isShowData ="isShowDataProvinceOrCity"

                                    :listFields="listFieldProvinceOrCity"
                                    :datas="listProvinceOrCitySource"

                                    inputText="LocationName"
                                    :propertyCompare="provinceOrCityIdTemp"
                                    keySearch="LocationId"

                                    @onChangeValueKeySearch ="changeIdProvinceOrCity"
                                    @input="changeInputProvinceOrCity"
                                    @updateIsShowData ="updateIsShowProvinceOrCity"
                                    ref="ProvinceOrCity" 
                                />
                            </div>
                            <div style="width: 32.5%">
                                <BaseComboboxNormal label="Quận/Huyện"
                                    v-model="objectFilterTemp.District"
                                    :isComboboxTable="true" :showField ="false"
                                    :errorCombobox="errorDistrict"
                                    :title="titleDistrict"
                                    :isShowData="isShowDataDistrict"

                                    :listFields="listFieldDistrict"
                                    :datas="listDistrictTemp"

                                    inputText="LocationName"
                                    :propertyCompare="districtIdTemp"
                                    keySearch="LocationId"

                                    @onChangeValueKeySearch ="changeIdDistrict"
                                    @input="changeInputDistrict"
                                    @updateIsShowData ="updateIsShowDistrict"

                                    ref="District"
                                />
                            </div>
                            <div style="width: 32.5%">
                                <BaseComboboxNormal label="Xã/Phường" 
                                    v-model="objectFilterTemp.WardOrCommune"
                                    :isComboboxTable="true" :showField ="false"
                                    :errorCombobox="errorWardOrCommune"
                                    :title="titleWardOrCommune"
                                    :isShowData ="isShowDataWardOrCommune"

                                    :listFields="listFieldWardOrCommune"
                                    :datas="listWardOrCommuneTemp"

                                    inputText="LocationName"
                                    :propertyCompare="wardOrCommuneIdTemp"
                                    keySearch="LocationId"

                                    @onChangeValueKeySearch ="changeIdWardOrCommune"
                                    @input="changeInputWardOrCommune"
                                    @updateIsShowData ="updateIsShowWardOrCommune"

                                    ref="WardOrCommune"
                                />
                            </div>
                        </div>
                        <div class="line-dropdown-filter"></div>
                        <div class="row-two">
                            <BaseButton label="Đặt lại" @btnClick="btnClickResetFilter"/>
                            <BaseButton label="Lọc" :hasBackground="true" @btnClick="btnClickFilterInDropdown"/>
                        </div>    
                    </div>
                </div>
                <div class="function-right">
                    <BaseInput typeInput="input" :hasIcon="true" placeholder="Nhập từ khóa tìm kiếm" v-model="keywordSearch"/>
                    <BaseButtonIcon iconClass="btn-refresh" title="Lấy lại dữ liệu"  @btnClick="showData"/>
                    <BaseButtonIcon iconClass="btn-excel" title="Xuất ra excel" @btnClick="btnExportExcel"/>
                    <BaseButtonIcon iconClass="btn-setting-background" title="Tùy chỉnh giao diện"/>
                </div>

            </div>
            <div class="ac-list-table">
                <BaseTableList
                    height="250px"
                    :listFields = "listFieldAccount"
                    :listData ="listAccount"
                    @btnView = 'btnSeeInfoAccount'
                    @btnDropDown = 'btnDropDown'
                    :nameTable="'AccountObject'"

                    @btnCheckbox='btnCheckboxItem'
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
     <BaseDropDownFunction v-if="isShowFunction"
        :duplicate="true"
        :remove="true"
        :edit ="true"
        :positionRight="67"
        :positionTop ="positionTopFunction"
        
        @hideFunction ="isShowFunction = false"
        @btnDuplicate="btnDuplicateAccount"
        @btnRemove="btnRemoveAccount"
        @btnEdit ="btnEditAccount"
    />
<AccountDetail v-if="isShowAccountDetail" :accountTable="accountSelected" :editMode="editModeTable"/>
<BaseLoading v-if="isShowLoading"/>
<BaseMessageRemove  v-if="isShowMessRemove" 
    typeMessage="warningAndQuestion" 
    :titleForm="titleMessRemove"
    @btnNo="isShowMessRemove = false"
    @btnYes="btnConfirmRemove"
/>
<BaseMessageInfo v-if="isShowMessInfo" 
    typeMessage="info" 
    :titleForm="titleMessInfo"
    @btnClose="isShowMessInfo = false"
/>
</div>


</template>

<script>
import BaseButton from '@/components/base/BaseButton.vue'
import BaseButtonIcon from '@/components/base/BaseButtonIcon.vue'
import BaseButtonFunction from '@/components/base/BaseButtonFunction.vue'
import BaseOverview from '@/components/base/BaseOverview.vue'
import BaseInput from '@/components/base/BaseInputNormal.vue'

import BaseTableList from '@/components/base/BaseTableList.vue'
import BaseTablePaging from '@/components/base/BaseTablePaging.vue'

import BaseDropDownFunction from '@/components/base/BaseDropDownFunction.vue'

import AccountDetail from '@/view/account_object/AccountDetail.vue'
import BaseComboboxNormal from '@/components/base/BaseComboboxNormal.vue'
import BaseLoading from '@/components/base/BaseLoading.vue'
import BaseMessageRemove from '@/components/base/BaseMessage.vue'
import BaseMessageInfo from '@/components/base/BaseMessage.vue'

import MyFunction from '@/js/function.js'
import * as mylib from '../../js/resourcs.js'
import axios from 'axios'
import * as location from '@/js/location.js'
export default {
    components: {
        BaseLoading,
        BaseButtonIcon,
        BaseButtonFunction,
        BaseOverview,
        BaseInput,
        BaseTableList,
        BaseTablePaging,
        BaseDropDownFunction,
        BaseMessageRemove,
        BaseMessageInfo,
        BaseComboboxNormal,
        BaseButton,

        AccountDetail
    },
    created(){
        var me = this;
        me.getData();
    },
    async mounted() {
        await this.getListAccountObjectGroup();//Thực hiện lấy dữ liệu của nhóm đối tượng
    },
   
    data() {
        return {
            isShowLoading:false,//Mặc định là đang đóng loading

            listFieldAccount: mylib.data.listFieldAccountObject,
            listAccount:null,//Dùng để lưu trữ list Employee
            isShowFunction:false,
            positionTopFunction:0,

            isShowPage: false,
            listPageText:mylib.data.listPageSize,
            totalRecord:0,
            pageAction:1,
            totalPage:1,
            selectTextPage: 20,

            listChecked :Array (),

            isShowAccountDetail:false,
            accountSelected:null,
            editModeTable:mylib.misaEnum.editMode.NoAction,//Mặc định đầu tiên là chưa làm gì cả

            keywordSearch:"",//Từ khóa tìm kiếm trong ô input

            titleMessInfo:mylib.resourcs["VI"].titleErrorRemoveAccountObject,
            titleMessRemove:null,
            isShowMessRemove:false,
            isShowMessInfo:false,
            
            listAccountObjectGroup:[],
            listFieldAccountObjectGroup:mylib.data.listFieldAccountObjectGroupCombobox,
            errorAccountObjectGroup:false,
            titleAccountObjectGroup:"",

            listFieldProvinceOrCity: mylib.data.listFieldProvinceOrCity,//Field của thành phố
            listFieldDistrict: mylib.data.listFieldDistrict,//Field của quận huyện
            listFieldWardOrCommune: mylib.data.listFieldWardOrCommune,//Field của xã phường

            listProvinceOrCitySource:location.resourcs.cities,//Nguồn chính của thành phố
            listDistrictSource:location.resourcs.district,//Nguồn chính của Quận huyện
            listDistrictTemp:[],//Thực sự truyền vào mỗi khi thay đổi giá trị của cha
            listWardOrCommuneSource:location.resourcs.wardOrCommune,//Nguồn chính của xã phường
            listWardOrCommuneTemp:[],//Thực sự truyền vào mỗi khi thay đổi giá trị của cha

            provinceOrCityIdTemp:null,//Các biến id giả để css thôi vì trong csdl không có
            districtIdTemp:null,//Các biến id giả để css thôi vì trong csdl không có
            wardOrCommuneIdTemp:null,//Các biến id giả để css thôi vì trong csdl không có

            errorProvinceOrCity:false,
            titleProvinceOrCity:"",
            errorDistrict:false,
            titleDistrict:"",
            errorWardOrCommune:false,
            titleWardOrCommune:"",

            isShowDataWardOrCommune:false,
            isShowDataDistrict:false,
            isShowDataProvinceOrCity:false,

            isShowFilterAccountObject:false,//Trạng thái của ô cửa sổ filter
            objectFilterTemp:{
                Type:"Tất cả",
                AccountObjectGroupCode:null,
                AccountObjectGroupId:null,
                ProvinceOrCity:null,
                District:null,
                WardOrCommune:null,

            },//Tạm thời trong filter
            objectFilter:{
                AccountObjectGroupCode: null,
                ProvinceOrCity:null,
                District:null,
                WardOrCommune:null,
            },//Lọc thật sự

            //Mảng dùng để lưu trữ toàn id xóa
            listAccountObjectRemove:new Array(),
            isShowRemoveMany:false,
            actionDelete:mylib.misaEnum.actionDelete.NoAction,//Đầu tiên là không thực hiện xóa gì
        }
    },
  
    watch: {
        /*Thực hiện theo dõi biến để load lại trang mong muốn đang làm
        *CreatedBy: HoaiPT(01/03/2022)
        */
        keywordSearch: function () {
            var me = this;
            clearTimeout(me.myTimeout);
            me.myTimeout = setTimeout(function () {
                me.pageAction = 1;//Thực hiện chuyển về trang đầu tiên
                me.showData();//Lấy lại dữ liệu
            }, 1000);
        },
        provinceOrCityIdTemp(valueNew){
            this.listDistrictTemp = this.listDistrictSource.filter(item => item.ParentId == valueNew);
        },
        districtIdTemp(valueNew){
            this.listWardOrCommuneTemp = this.listWardOrCommuneSource.filter(item => item.ParentId == valueNew);
        },
    },
    methods: {
        btnRemoveMany(){
            var me = this;
            me.isShowRemoveMany = false;//Thực hiện đóng xóa nhiều dropdown

            me.actionDelete = mylib.misaEnum.actionDelete.Multi;//Thực hiện xóa nhiều
            me.titleMessRemove = 'Bạn có thực sự muốn xóa những nhà cung cấp này không?';//Thể hiện title mong muốn
            me.isShowMessRemove = true;//Hiển thị xóa nhiều message
        },
        /**
         * Thực hiện click vào checkbox
         * CreatedBy: HoaiPT(19/03/2022)
         */
        btnCheckboxItem({id}){
            const item = document.getElementById(id);
            if(item.checked == true){
                this.listAccountObjectRemove.push(id);
            }else{
                this.listAccountObjectRemove = this.listAccountObjectRemove.filter(item => item != id)
            }
            console.log(this.listAccountObjectRemove);
        },

        /**
         * Thực hiện khi click vào nút đặt lại trong filter
         * CreatedBy: HoaiPT(19/03/2022)
         */
        btnClickResetFilter(){
            //Set hết mấy cái sử dụng temp ấy về null hết
            this.provinceOrCityIdTemp = null;
            this.districtIdTemp = null;
            this.wardOrCommuneIdTemp = null;

            //Set toàn bộ objectFilterTemp về giá trị ban đầu
            this.objectFilterTemp.Type = "Tất cả";
            this.objectFilterTemp.AccountObjectGroupCode = null;
            this.objectFilterTemp.AccountObjectGroupId = null;
            this.objectFilterTemp.ProvinceOrCity = null;
            this.objectFilterTemp.District = null;
            this.objectFilterTemp.WardOrCommune = null;

            //Nếu có lỗi ở những ô thì về trạng thái ban đầu không lỗi gì hết
            this.errorProvinceOrCity = false;
            this.titleProvinceOrCity ="";
            this.errorDistrict =false;
            this.titleDistrict = "";
            this.errorWardOrCommune= false;
            this.titleWardOrCommune = "";
            this.errorAccountObjectGroup = false;
            this.titleAccountObjectGroup = "";

        },
        /**
         * Thực hiện khi click vào xóa bộ lọc
         * CreatedBy: HoaiPT(19/03/2022)
         */
        async btnRemoveAllFilter(){
            let objectTemp ={};//Rỗng
            this.objectFilter = MyFunction.sameObjectDestination(this.objectFilter, objectTemp);
            await this.showData();
        },
        /**
         * Thực hiện kiểm tra xem bộ lọc ấy có tồn tại giá trị hay không 
         * Nếu có thì hiện xóa bộ lọc còn không có có giá trị nào thì không hiển thị xóa bộ lọc
         * CreatedBy: HoaiPT(19/03/2022)
         */
        exitObjectFilter(){
            for(var propName in this.objectFilter){
                if(this.objectFilter[propName] !=null){
                    if(this.objectFilter[propName] !=""){
                        return true;
                    }
                }
            }
            return false;
        },
        /**
         * Thực hiện khi click vào nút xóa item ở bộ lọc
         * CreatedBy: HoaiPT(18/03/2022)
         */
        async btnClickRemoveInItemFilter(value,propName){
            this.objectFilter[propName] = null;
            await this.showData();//Load dữ liệu
        },
        /**
         * Thực hiện khi click vào nút lọc ở dropdown
         * CreatedBy: HoaiPT(18/03/2022)
         */
        async btnClickFilterInDropdown(){
            var me = this;
            if(!me.validateAccountObjectGroup()){
                return;
            }
            if( ! me.validateAddressFilter()){
                return;
            }
            this.objectFilter = MyFunction.sameObjectDestination(this.objectFilter, this.objectFilterTemp);
            this.isShowFilterAccountObject = false;//Thực hiện đóng filter

            await this.showData();//Load dữ liệu

        },
        /**
         * Thực hiện validate ở AccountObjectGroup
         * CreatedBy: HoaiPT(18/03/2022)
         */
        validateAccountObjectGroup(){
            if(this.objectFilterTemp.AccountObjectGroupId == null && this.objectFilterTemp.AccountObjectGroupCode !=null){//Nếu id bằng null mà code lại khác null 
                if(this.objectFilterTemp.AccountObjectGroupCode !=""){
                    this.errorAccountObjectGroup = true;
                    this.titleAccountObjectGroup = "Không tồn tại mã nhóm nhà cung cấp này! ";
                    this.$refs.AccountObjectGroup.focus();//Tập trung vào ô mã nhóm nhà cung cấp
                    return false;
                }
            }
            return true;
        },
        /**
         * Thực hiện Validate Address
         * CreadBy: HoaiPT(17/03/2022)
         * UpdateBy: HoaiPT(19/03/2022)
         */
        validateAddressFilter(){
            var me = this;
            if(me.objectFilterTemp.ProvinceOrCity != null){//Nếu mà nó có tồn tại
                if(me.objectFilterTemp.ProvinceOrCity !="" && me.provinceOrCityIdTemp == null){//Nếu nó có giá trị mà id vẫn bằng null
                    me.titleProvinceOrCity = mylib.resourcs["VI"].notProvinceOrCity;
                    me.errorProvinceOrCity = true;
                    this.$refs.ProvinceOrCity.focus();//Tập trung vào ô tỉnh/thành phố lỗi
                    return false;
                }
            }

            if(me.objectFilterTemp.District != null){//Nếu mà nó có tồn tại
                if(me.objectFilterTemp.District !="" && me.districtIdTemp == null){//Nếu nó có giá trị mà id vẫn bằng null
                    me.titleDistrict = mylib.resourcs["VI"].notDistrict;
                    me.errorDistrict = true;
                    this.$refs.District.focus();//Tập trung vào ô quận huyện lỗi
                    return false;
                }
            }

            if(me.objectFilterTemp.WardOrCommune != null){//Nếu mà nó có tồn tại
                if(me.objectFilterTemp.WardOrCommune !="" && me.wardOrCommuneIdTemp == null){//Nếu nó có giá trị mà id vẫn bằng null
                    me.titleWardOrCommune = mylib.resourcs["VI"].notWardOrCommune;
                    me.errorWardOrCommune = true;
                    this.$refs.WardOrCommune.focus();//Tập trung vào ô xã phường lỗi
                    return false;
                }
            }
            return true;
        },
        /**
         * Thực hiện update lại trạng thái của data xã phường
         * CreatedBy: HoaiPT(18/03/2022)
         */
        updateIsShowWardOrCommune(status){
            this.isShowDataWardOrCommune = status;
        },
        /**
         * Thực hiện khi thay đổi input của xã phường
         * CreatedBy: HoaiPT(18/03/2022)
         */
        changeInputWardOrCommune(){
            this.wardOrCommuneIdTemp = null;
            this.errorWardOrCommune = false;//Nếu có viền đỏ thì bỏ
            this.titleWardOrCommune = "";//Và title cũng bỏ
        },
        /**
         * Thực hiện khi thay đổi giá trị Id của xã phường
         * CreatedBy: HoaiPT(18/03/2022)
         */
        changeIdWardOrCommune(object){
            this.wardOrCommuneIdTemp = object.LocationId;
        },
        /**
         * Thực hiện update lại trạng thái của data quận huyện
         * CreatedBy: HoaiPT(18/03/2022)
         */
        updateIsShowDistrict(status){
            this.isShowDataDistrict = status;
        },
        /**
         * Thực hiện khi thay đổi input của quận huyện
         * CreatedBy: HoaiPT(18/03/2022)
         */
        changeInputDistrict(){
            this.districtIdTemp = null;
            this.errorDistrict = false;//Nếu có viền đỏ thì bỏ
            this.titleDistrict = "";//Và title cũng bỏ
            this.listWardOrCommuneTemp =[];

            this.objectFilterTemp.WardOrCommune ="";
            this.isShowDataWardOrCommune = false;

            this.wardOrCommuneIdTemp = null;
        },
        /**
         * Thực hiện khi select thay đổi giá trị id của quận huyện
         * CreatedBy: HoaiPT(18/03/2022)
         */
        changeIdDistrict(object){
            this.districtIdTemp = object.LocationId;
        },
        /**
         * Thực hiện cập nhật của data tỉnh thành phố
         * CreatedBy: HoaiPT(18/03/2022)
         */
        updateIsShowProvinceOrCity(status){
            this.isShowDataProvinceOrCity = status;
        },
        /**
         * Thực hiện khi thay đổi giá trị input của tỉnh thành phố
         * CreatedBy: HoaiPT(18/03/2022)
         */
        changeInputProvinceOrCity(){
            this.provinceOrCityIdTemp = null;
            this.errorProvinceOrCity = false;//Nếu có viền đỏ thì bỏ
            this.titleProvinceOrCity = "";//Và title cũng bỏ
            this.listDistrictTemp =[];
            this.listWardOrCommuneTemp =[];

            this.objectFilterTemp.District="";
            this.isShowDataDistrict = false;
            this.objectFilterTemp.WardOrCommune ="";
            this.isShowDataWardOrCommune = false;
            
            this.districtIdTemp = null;
            this.wardOrCommuneIdTemp = null;
        },
        /**
         * Thực hiện khi select giá trị của tỉnh thành phố
         * CreatedBy: HoaiPT(18/03/2022)
         */
        changeIdProvinceOrCity(object){
            this.provinceOrCityIdTemp = object.LocationId;
        },
        /**
         * Thực hiện khi thay đổi ô input của AccountObjectGroup
         * CreatedBy: HoaiPT(18/03/2022)
         */
        changeInputAccountObjectGroup(){
            this.objectFilterTemp.AccountObjectGroupId = null;
            this.errorAccountObjectGroup = false;//Nếu có viền đỏ thì thì thực hiện xóa
            this.titleAccountObjectGroup ="";
        },
        /**
         * Thực hiện khi select id của AccountObjectGroup
         * CreatedBy: HoaiPT(18/03/2022)
         */
        changeIdAccountObjectGroup(object){
            this.objectFilterTemp.AccountObjectGroupId = object.AccountObjectGroupId;
        },
       
        /**
         * Thực hiện khi click vào nút lọc màu trắng ở trên list table
         * CreatedBy: HoaiPT(18/03/2022)
         */
        btnClickFilterList(){
            this.isShowFilterAccountObject = !this.isShowFilterAccountObject;//Thực hiện hiển thị bộ lọc hoặc ẩn bộ lọc khi ấn vào nút lọc
        },

        /**
         * Thực hiện xem thông tin của nhà cung cấp 
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnSeeInfoAccount({object}){
            var me = this;
            me.editModeTable = mylib.misaEnum.editMode.View;//Thực hiện xem thông tin 

            me.accountSelected = object;//Thực hiện gián rỗng đối tượng mới
            me.isShowAccountDetail = true;//Thực hiện mở form detail
            
        },
         /**
         * Thực hiện khi click vào nút dropdown của mỗi dòng của function 
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnDropDown({eve, object, index }){
            var me = this;
            console.log(index);
            me.accountSelected = object;//Gián giá trị đối tượng dòng đang chọn vào đối tượng đang chờ để thực hiện thao tác

            //Thực hiện truyền tọa độ thích hợp cho dropdown 
            me.positionTopFunction = eve.clientY < 500 ? (eve.clientY + 14) : (eve.clientY - 105);
            me.isShowFunction = true;
            
        },
        
        /**
         * Thực hiện khi click vào nút sửa trong dropdown 
         * CreatedBy: HoaiPT(28/02/2022)
         */
        btnEditAccount(){
            var me  = this;
            me.editModeTable = mylib.misaEnum.editMode.Edit;//Thực hiện Sửa thông tin
            me.isShowFunction = false;
            me.isShowAccountDetail = true;//Mở form detail
        },  
         /**
         * Thực hiện khi click vào nút xác nhận xóa
         * CreatedBy: HoaiPT(01/03/2022)
         */
        btnConfirmRemove(){
            try {
                var me = this;
                let tempListAccountObjectRemove = me.listAccountObjectRemove;
                MyFunction.removeChecked(me.listAccountObjectRemove);//Thực hiện bỏ checked
                me.listAccountObjectRemove =[];//Làm mới rỗng

                switch (me.actionDelete) {
                    case mylib.misaEnum.actionDelete.One:
                        axios.delete(`https://localhost:44338/api/v1/AccountObjects/${this.accountSelected.AccountObjectId}`)
                        .then(function () {          
                            //Đóng form
                            me.isShowMessRemove = false;//Đóng form xóa
                            me.getData();//Thực hiện load lại dữ liệu
                        })
                        .catch(function () {
                            //Trường hợp lỗi không xóa được thông tin lỗi đã ghi ở resource ở chỗ data return rồi
                            me.isShowMessRemove = false;//Thực hiện đóng form xóa

                            //Thực hiện mở form thông báo lỗi
                            me.isShowMessInfo = true;
                        })
                        break;
                    case mylib.misaEnum.actionDelete.Multi:
                        console.log(tempListAccountObjectRemove);//Thực hiện nếu xóa thì xóa cái này
                        console.log("thực hiện xóa nhiều");
                        break;
                    default:
                        break;
                }
                
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện khi click vào nút xóa trong td
         * CreatedBy: HoaiPT(01/03/2022)
         */
        btnRemoveAccount(){    
            var me = this;
            me.isShowFunction = false;//Đóng dropdown function
            me.isShowRemoveMany = false;//Thực hiện đóng xóa nhiều nếu mở 
            
            me.titleMessRemove = `Bạn có thực sự muốn xóa Nhà cung cấp <${me.accountSelected.AccountObjectCode}> không?`;
            
            me.actionDelete = mylib.misaEnum.actionDelete.One;//Thực hiện xóa 1;
            me.isShowMessRemove = true;//Thực hiện mở form remove
        },
        
        /**
         * Thực hiện khi click vào nút nhân bản trong dropdown
         * CreatedBy: HoaiPT(01/03/2022)
         */
        async btnDuplicateAccount(){
            var me = this;
            me.isShowFunction = false;//Thực hiện đóng function
            me.editModeTable = mylib.misaEnum.editMode.Add;//Thực hiện thêm mới

            //AccountObject thì bằng cái lúc mà click vào nút dropdown rồi đó là me.accountSelected  ấy
            await me.getCodeNew();//Thực hiện lấy ra mã mới

            me.isShowAccountDetail = true;//Thực hiện mở form detail
        },
         /**
         * Thực hiện khi click vào nút thêm trong Account List
         * CreatedBy: HoaiPT(28/02/2022)
         */
        async btnAddAccount(){
            var me = this;
            me.editModeTable = mylib.misaEnum.editMode.Add;//Thực hiện thêm mới
            me.accountSelected = {};//Thực hiện gián rỗng đối tượng mới
           
           await me.getCodeNew();//Thực hiện lấy ra mã mới

            me.isShowAccountDetail = true;//Thực hiện mở form detail
            
        },
        /**
         * Thực hiện khi click vào kích thước trang mong muốn
         * UpdateBy: HoaiPT(01/03/2022)
         */
        async selectedPageText({index}){
            var me = this;
            me.selectTextPage = me.listPageText[index]; //Thực hiện gán số kích thước trang đã lựa chọn 
            me.pageAction = 1;//Chuyển về trang đầu tiên
            me.isShowPage = false; //Đóng form page
            
            await me.showData();
        },
        /**
         * Thực hiện khi click vào nút mở kích thước trang
         * UpdateBy: HoaiPT(01/03/2022)
         */
        btnSelectPage(){
            var me =this;
            me.isShowPage = !me.isShowPage;
        },
        /**
         * Thực hiện khi click vào trang mong muốn
         * UpdateBy: HoaiPT(01/03/2022)
         */
        async clickCallback({number}){
            var me = this;
            me.pageAction = number;
            await me.showData();
        },
        /**
         * Lấy toàn bộ dữ liệu về trạng thái ban đầu
         * CreatedBy: HoaiPT(17/02/2022)
         * UpdateBy: HoaiPT(01/03/2022)
         */
        getData() {
            //Chắc chắn là con trỏ this đang ở đây;
            var me = this;
            me.selectTextPage = 20; //Reset lại số lượng bản ghi trên 1 trang 
            me.pageAction = 1; //Reset lại số trang  đang hiển thị

            me.keywordSearch = "";
            me.showData(); //Load dữ liệu
        },
        /**
         * Lấy và gán dữ liệu dữ liệu
         * CreatedBy: HoaiPT(17/02/2022)
         * UpdateBy: HoaiPT(01/03/2022)
         */
        async showData() {
            try {
                var me = this;
                me.isShowLoading = true; //Thực hiện mở Loading
                await axios.post(`https://localhost:44338/api/v1/AccountObjects/GetPageV2?searchText=${me.keywordSearch}&pageIndex=${me.pageAction}&pageSize=${me.selectTextPage}`,this.objectFilter)
                    .then(function (res) {
                        me.listAccount = res.data.Data; //Thực hiện gián listEmployee vào với kích thước trang, từ khóa tìm kiếm và trang đang đứng
                        me.totalPage = Number(res.data.TotalPage); //Gán vào tổng số trang
                        me.totalRecord = res.data.TotalRecord; //Gán vào tổng số bản ghi
                        me.isShowLoading = false; //Đóng loading
                    })
                    .catch(function (res) {
                        console.log(res);
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện export Excel
         * CreatedBy: HoaiPT(14/02/2022)
         * UpdateBy: HoaiPT(01/03/2022)
         */
        btnExportExcel() {
            try {
                //Chắc chắn là con trỏ this đang ở đây;
                var me = this;
                me.isShowLoading = true; //Hiển thị đang load
                axios.get('https://localhost:44338/api/v1/AccountObjects/Excel', {
                    responseType: 'blob',
                }).then((response) => {
                    const url = URL.createObjectURL(new Blob([response.data]));
                    const link = document.createElement('a'); //Tạo ra một element mới là thẻ a
                    link.href = url; //Thẻ a này có đường dẫn là file excel trả về từ database
                    link.setAttribute(
                        'download',
                        `${mylib.resourcs["VI"].fileNameAccountObjectExport}-${new Date().toLocaleDateString()}.xlsx` //File excel tải về có dạng như vậy
                    )
                    document.body.appendChild(link); //Thêm đường link mới này vào trong file html
                    link.click();
                    me.isShowLoading = false; //Đóng Loading
                })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện lấy mã code mới tự sinh
         * CreatedBy: HoaiPT(15/02/2022)
         * UpdateBy: HoaiPT(01/03/2022)
         */
        async getCodeNew() {
            try {
                var me = this;
                me.isShowLoading = true; //Hiển thị đang load
                await axios.get('https://localhost:44338/api/v1/AccountObjects/CodeNew')
                    .then(function (res) {
                        me.accountSelected.AccountObjectCode = res.data;//Gán mã mới
                        me.isShowLoading = false; //đóng load
                    })
                    .catch(function (res) {
                        console.error(res);
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
        /**
         * Thực hiện lấy listAccountObjectGroup
         * CreatedBy: HoaiPT(18/03/2022)
         */
         async getListAccountObjectGroup() {
            try {
                var me = this;
                await axios.get('https://localhost:44338/api/v1/AccountObjectGroups')
                    .then(function(res) {
                        me.listAccountObjectGroup = res.data;
                    })
            } catch {
                console.log(mylib.resourcs["VI"].errorMsg);
            }
        },
    },
}
</script>

<style scoped>
@import url(../../style/view/account_object/account-list.css);
</style>
