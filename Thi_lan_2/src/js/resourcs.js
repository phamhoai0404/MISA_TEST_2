var resourcs = {
    VI: {
        errorMsg: "Có lỗi xảy ra vui lòng liên hệ Misa! ",
        titlePage: " bản ghi trên 1 trang",
        fileNameEmployeeExport: "Danh_sach_nhan_vien",
        fileNameAccountObjectExport: "Danh_sach_nha_cung_cap",
        deleteMulti: "Bạn thực sự có muốn xóa những nhân viên đã chọn không?",
        confirmEdit: "Dữ liệu đã bị thay đổi bạn có muốn cất không?",
        errorFormatCode: "Mã không đúng định dạng!",
        notNullFullName: "Tên không được phép để trống!",
        notNullCode: "Mã không được phép để trống!",
        notNullAll: " không được phép để trống!",
        inputSearch: "Nhập từ khóa tìm kiếm",

        titleErrorRemoveAccountObject: "Xóa không thành công, Mã đã có phát sinh !",

        notNullName: "Tên không được để trống!",

        notExistEmployeeId: "Không tồn tại mã nhân viên!",
        notExistPayAccountId: "Không tồn tại mã tài khoản công nợ!",
        notExistPaymentTermId: "Không tồn tại mã tài điều khoản!",
        notExistAccountObjectGroupId: "Không tồn tại nhóm mã nhà cung cấp!",
    }
}
var misaEnum = {
    gender: {
        Male: "1",
        Female: "0",
        Other: "2"
    },
    genderNumber: {
        Male: {
            Value: 1,
            Text: "Nam"
        },
        Female: {
            Value: 0,
            Text: "Nữ"
        },
        Other: {
            Value: 2,
            Text: "Khác"
        }
    },
    editMode: {
        NoAction: 0, //Không thực hiện gì cả
        Add: 1, //Thực hiện thêm mới
        Edit: 2, //Thực hiện sửa
        View: 3 //Thực hiện xem
    },
    actionDelete: {
        NoAction: 0, //Không xóa
        One: 1, //Xóa một 
        Multi: 2, //Xóa nhiều
    }
}
var data = {
    listPageSize: [
        "10", "20", "30", "50", "100"
    ],
    listFieldAccountObject: [{
            name: "AccountObjectCode",
            text: "MÃ NHÀ CUNG CẤP",
            width: "130",
        },
        {
            name: "AccountObjectName",
            text: "TÊN NHÀ CUNG CẤP",
            width: "180",
        },
        {
            name: "Address",
            text: "ĐỊA CHỈ",
            width: "120",
        },
        {
            name: "TaxCode",
            text: "MÃ SỐ THUẾ",
            width: "100",
        },
        {
            name: "Phone",
            text: "SỐ ĐIỆN THOẠI",
            width: "115",
        },
        {
            name: "Website",
            text: "WEBSITE",
            width: "200",
            title: "Tên trang web công ty"
        },
        {
            name: "CreatedDate",
            text: "NGÀY TẠO",
            width: "115",
            type: "date"

        },
        {
            name: "MaximizeDebtAmount",
            text: "NỢ TỐI ĐA",
            width: '80',
            type: 'number'
        }

    ],
    listTabIndex: [
        "Liên hệ", "Điều khoản thanh toán", "Tài khoản ngân hàng", "Địa chỉ khác", "Ghi chú"
    ],
    listPrefix: [
        "Ông", "Bà", "Anh", "Chị", "Chú", "Cô", "Mrs", "Mr"
    ],
    listFieldEmployeeCombobox: [{
            name: "EmployeeCode",
            text: "Mã nhân viên",
            width: "40%",
            title: "Tên trang web công ty",
        },
        {
            name: "FullName",
            text: "Tên nhân viên",
            width: "60%",
            title: "Tên trang web công ty"
        },
        // {
        //     //     name: "CreatedDate",
        //     text: "Test ngày",
        //     width: "60",
        //     title: "Tên trang web công ty",
        //     type: "date"
        // },
        // {
        //     name: "Gender",
        //     text: "Test số",
        //     width: "60",
        //     title: "Tên trang web công ty",
        //     type: "number"
        // },
    ],
    listFieldPayAccountCombobox: [{
            name: "PayAccountCode",
            text: "Số tài khoản",
            width: "45%"
        },
        {
            name: "PayAccountName",
            text: "Tên tài khoản",
            width: "55%"
        },
    ],
    listFieldPaymentTermCombobox: [{
            name: "PaymentTermCode",
            text: "Mã điều khoản thanh toán",
            width: "45%"
        },
        {
            name: "PaymentTermName",
            text: "Tên điều khoản thanh toán",
            width: "55%"
        },
    ],
    listFieldAccountObjectGroupCombobox: [{
            name: "AccountObjectGroupCode",
            text: "Mã nhóm KH, NCC",
            width: "40%"
        },
        {
            name: "AccountObjectGroupName",
            text: "Tên nhóm KH, NCC",
            width: "60%"
        },
    ],

}


var dataTest = {
    listAccount: [{
            "AccountObjectId": "11452b0c-768e-5ff7-0d63-eeb1d8ed8cef",
            "AccountObjectCode": "NCC00004",
            "AccountObjectName": "Công ty MKUGN",
            "TaxCode": "143571",
            "Phone": "0336302541",
            "Website": "http://minh1331.vn",
            "AccountObjectGroupListId": null,
            "Address": "Thừa Thiên Huế",
            "EmployeeId": "4989ff24-23e7-7b82-b6d2-89b22d10517e",
            "Prefix": "Ông",
            "EinvoiceContactName": "Nguyễn Hồ Trang",
            "EinvoiceContactMobile": "0875946171",
            "EinvoiceContactEmail": "Anh778@gmail.com",
            "LegalRepresentative": "Nguyễn Văn Tuấn",
            "PaymentTermId": "60b82625-3612-24de-9617-6d44a4db1359",
            "MaximizeDebtAmount": 20,
            "DueTime": 11,
            "AccountObjectBankAccount": null,
            "AccountObjectShippingAddress": null,
            "Country": "Việt Nam",
            "District": null,
            "WardOrCommune": null,
            "ProvinceOrCity": "Thừa Thiên Huế",
            "Description": "",
            "PayAccountId": "548dce5f-5f29-4617-725d-e2ec561b0f41",
            "CreatedDate": "2007-05-21T20:18:55",
            "CreatedBy": "Adolph Francisco",
            "ModifiedDate": "11/08/1986 03:05:24",
            "ModifiedBy": "Jason Blackmon"
        },
        {
            "AccountObjectId": "1152da18-24d8-65b6-0380-e8e2a817c80e",
            "AccountObjectCode": "NCC00049",
            "AccountObjectName": "Công ty KJHUM",
            "TaxCode": "107547",
            "Phone": "0329500933",
            "Website": "http://minh1692.edu",
            "AccountObjectGroupListId": null,
            "Address": "Nam Định",
            "EmployeeId": "6a763a51-4322-5c5a-b5d2-89b22d10517e",
            "Prefix": "Ông",
            "EinvoiceContactName": "Trần Thế Huy",
            "EinvoiceContactMobile": "0334551308",
            "EinvoiceContactEmail": "Tuy206@gmail.com",
            "LegalRepresentative": "Đỗ Thị Phương",
            "PaymentTermId": "359963d8-1e69-5220-7ecc-ee92bf437a3f",
            "MaximizeDebtAmount": 50,
            "DueTime": 14,
            "AccountObjectBankAccount": null,
            "AccountObjectShippingAddress": null,
            "Country": "Việt Nam",
            "District": null,
            "WardOrCommune": null,
            "ProvinceOrCity": "Nam Định",
            "Description": "",
            "PayAccountId": "5bd71cda-209f-2ade-54d1-35c781481818",
            "CreatedDate": "2005-09-21T09:43:48",
            "CreatedBy": "Shonda Leake",
            "ModifiedDate": "01/01/1970 00:05:07",
            "ModifiedBy": "Marylin Bankston"
        },
        {
            "AccountObjectId": "11f7089b-33e6-371a-f817-7000f455f3d5",
            "AccountObjectCode": "NCC00021",
            "AccountObjectName": "Công ty DRNAL",
            "TaxCode": "183315",
            "Phone": "0347351171",
            "Website": "http://ngoc3282.com",
            "AccountObjectGroupListId": null,
            "Address": "Long An",
            "EmployeeId": "1f85f165-3ed3-370a-b7d2-89b22d10517e",
            "Prefix": "Bà",
            "EinvoiceContactName": "Nguyễn Thế Hoàng",
            "EinvoiceContactMobile": "0817926108",
            "EinvoiceContactEmail": "Song22945@gmail.com",
            "LegalRepresentative": "Phạm Văn Hoàng",
            "PaymentTermId": "49b5613c-112f-5d16-636f-d59c8dd9bef2",
            "MaximizeDebtAmount": 17,
            "DueTime": 80,
            "AccountObjectBankAccount": null,
            "AccountObjectShippingAddress": null,
            "Country": "Việt Nam",
            "District": null,
            "WardOrCommune": null,
            "ProvinceOrCity": "Long An",
            "Description": "",
            "PayAccountId": "5bd71cda-209f-2ade-54d1-35c781481818",
            "CreatedDate": "1973-12-04T23:45:59",
            "CreatedBy": "Delcie Abney",
            "ModifiedDate": "01/01/1970 02:09:09",
            "ModifiedBy": "Corinna Bratton"
        },
        {
            "AccountObjectId": "142cb08f-7c31-21fa-8e90-67245e8b283e",
            "AccountObjectCode": "NCC00000",
            "AccountObjectName": "Công ty MVOXN",
            "TaxCode": "155986",
            "Phone": "0395601922",
            "Website": "http://ngoc5955.com",
            "AccountObjectGroupListId": null,
            "Address": "An Giang",
            "EmployeeId": "1e5e96fa-5d7a-599d-27c2-579daad24557",
            "Prefix": "Ông",
            "EinvoiceContactName": "Vũ Văn Anh",
            "EinvoiceContactMobile": "0331755304",
            "EinvoiceContactEmail": "Vanh04612@gmail.com",
            "LegalRepresentative": "Nguyễn Tiến Huy",
            "PaymentTermId": "2181e1b4-3cf9-2495-bbec-c0283040ad25",
            "MaximizeDebtAmount": 88,
            "DueTime": 79,
            "AccountObjectBankAccount": null,
            "AccountObjectShippingAddress": null,
            "Country": "Việt Nam",
            "District": null,
            "WardOrCommune": null,
            "ProvinceOrCity": "An Giang",
            "Description": "",
            "PayAccountId": "548dce5f-5f29-4617-725d-e2ec561b0f41",
            "CreatedDate": "1970-01-01T00:07:13",
            "CreatedBy": "Letha Bolt",
            "ModifiedDate": "01/01/1970 00:00:04",
            "ModifiedBy": "Abraham Acevedo"
        },
        {
            "AccountObjectId": "14c0ce35-1687-459c-1acb-66948daf6128",
            "AccountObjectCode": "NCC00032",
            "AccountObjectName": "Công ty KQAZJ",
            "TaxCode": "170684",
            "Phone": "0843377579",
            "Website": "http://lan4697.vn",
            "AccountObjectGroupListId": null,
            "Address": "Hòa Bình",
            "EmployeeId": "62af2231-78a7-7caa-cd1d-086412a8ea97",
            "Prefix": "Bà",
            "EinvoiceContactName": "Vũ Thị Phương",
            "EinvoiceContactMobile": "0341846922",
            "EinvoiceContactEmail": "Lam51039@gmail.com",
            "LegalRepresentative": "Vũ Bảo Bảo",
            "PaymentTermId": "2181e1b4-3cf9-2495-bbec-c0283040ad25",
            "MaximizeDebtAmount": 94,
            "DueTime": 31,
            "AccountObjectBankAccount": null,
            "AccountObjectShippingAddress": null,
            "Country": "Việt Nam",
            "District": null,
            "WardOrCommune": null,
            "ProvinceOrCity": "Hòa Bình",
            "Description": "",
            "PayAccountId": "589edf01-198a-4ff5-958e-fb52fd75a1d4",
            "CreatedDate": "1970-01-01T00:01:38",
            "CreatedBy": "Melia Gates",
            "ModifiedDate": "04/16/2009 01:11:50",
            "ModifiedBy": "Dong Alarcon"
        },
        {
            "AccountObjectId": "17120d02-6ab5-3e43-18cb-66948daf6128",
            "AccountObjectCode": "NCC00003",
            "AccountObjectName": "Công ty IUMMC",
            "TaxCode": "127623",
            "Phone": "0885979808",
            "Website": "http://lan3337.edu",
            "AccountObjectGroupListId": null,
            "Address": "Ninh Bình",
            "EmployeeId": "409dcd1a-426a-23f7-3a35-0028ed526dd0",
            "Prefix": "Ông",
            "EinvoiceContactName": "Vũ Phương Nhung",
            "EinvoiceContactMobile": "0937357757",
            "EinvoiceContactEmail": "Nga798@gmail.com",
            "LegalRepresentative": "Lý Thảo Anh",
            "PaymentTermId": "359963d8-1e69-5220-7ecc-ee92bf437a3f",
            "MaximizeDebtAmount": 56,
            "DueTime": 20,
            "AccountObjectBankAccount": null,
            "AccountObjectShippingAddress": null,
            "Country": "Việt Nam",
            "District": null,
            "WardOrCommune": null,
            "ProvinceOrCity": "Ninh Bình",
            "Description": "",
            "PayAccountId": "589edf01-198a-4ff5-958e-fb52fd75a1d4",
            "CreatedDate": "1999-03-08T13:32:34",
            "CreatedBy": "Miyoko Mckinney",
            "ModifiedDate": "03/12/2018 12:55:48",
            "ModifiedBy": "Hong Beaudoin"
        },
        {
            "AccountObjectId": "179d5bc0-2405-67f7-9590-67245e8b283e",
            "AccountObjectCode": "NCC00052",
            "AccountObjectName": "Công ty YOSET",
            "TaxCode": "128850",
            "Phone": "0318948993",
            "Website": "http://ngoc5358.vn",
            "AccountObjectGroupListId": null,
            "Address": "Phú Thọ",
            "EmployeeId": "407db4d1-222b-287d-0135-60b3ebf808a9",
            "Prefix": "Bà",
            "EinvoiceContactName": "Nguyễn Đình Nam",
            "EinvoiceContactMobile": "0319299327",
            "EinvoiceContactEmail": "Ly166@gmail.com",
            "LegalRepresentative": "Trần Ngọc Hoàng",
            "PaymentTermId": "359963d8-1e69-5220-7ecc-ee92bf437a3f",
            "MaximizeDebtAmount": 29,
            "DueTime": 29,
            "AccountObjectBankAccount": null,
            "AccountObjectShippingAddress": null,
            "Country": "Việt Nam",
            "District": null,
            "WardOrCommune": null,
            "ProvinceOrCity": "Phú Thọ",
            "Description": "",
            "PayAccountId": "68daa090-552d-1bc6-e8e4-8adc5263917a",
            "CreatedDate": "2017-11-23T22:08:26",
            "CreatedBy": "Alphonso Meeks",
            "ModifiedDate": "04/24/1984 17:16:19",
            "ModifiedBy": "Dimple Alba"
        },
        {
            "AccountObjectId": "1b336f56-7ee3-7ceb-1ccb-66948daf6128",
            "AccountObjectCode": "NCC00056",
            "AccountObjectName": "Công ty JJEND",
            "TaxCode": "154668",
            "Phone": "0371170316",
            "Website": "http://ngoc7384.com",
            "AccountObjectGroupListId": null,
            "Address": "Vĩnh Long",
            "EmployeeId": "5de704c2-573f-1a71-1a80-de64d090a2c2",
            "Prefix": "Bà",
            "EinvoiceContactName": "Lý Phương Linh",
            "EinvoiceContactMobile": "0390313338",
            "EinvoiceContactEmail": "Van6529@misa.com",
            "LegalRepresentative": "Phan Phan Hoàng",
            "PaymentTermId": "26a546dc-51ef-474e-ec75-f433c80be791",
            "MaximizeDebtAmount": 33,
            "DueTime": 15,
            "AccountObjectBankAccount": null,
            "AccountObjectShippingAddress": null,
            "Country": "Việt Nam",
            "District": null,
            "WardOrCommune": null,
            "ProvinceOrCity": "Vĩnh Long",
            "Description": "",
            "PayAccountId": "30d41e52-5e66-72bc-6c1c-b47866e0b131",
            "CreatedDate": "1970-01-01T00:04:31",
            "CreatedBy": "Alejandro Espinal",
            "ModifiedDate": "01/01/1970 00:00:18",
            "ModifiedBy": "Glory Hammond"
        },
        {
            "AccountObjectId": "1ded3dd7-32db-5bc9-9190-67245e8b283e",
            "AccountObjectCode": "NCC00019",
            "AccountObjectName": "Công ty YWSKM",
            "TaxCode": "157693",
            "Phone": "0974266355",
            "Website": "http://tri2836.vn",
            "AccountObjectGroupListId": null,
            "Address": "Tuyên Quang",
            "EmployeeId": "197fda97-5a35-781d-0e77-d9ebc53aac3d",
            "Prefix": "Bà",
            "EinvoiceContactName": "Vũ Thảo Trang",
            "EinvoiceContactMobile": "0985565339",
            "EinvoiceContactEmail": "Trinh9890@gmail.com",
            "LegalRepresentative": "Phạm Thị Yến",
            "PaymentTermId": "26a546dc-51ef-474e-ec75-f433c80be791",
            "MaximizeDebtAmount": 85,
            "DueTime": 13,
            "AccountObjectBankAccount": null,
            "AccountObjectShippingAddress": null,
            "Country": "Việt Nam",
            "District": null,
            "WardOrCommune": null,
            "ProvinceOrCity": "Tuyên Quang",
            "Description": "",
            "PayAccountId": "589edf01-198a-4ff5-958e-fb52fd75a1d4",
            "CreatedDate": "1997-03-20T09:03:51",
            "CreatedBy": "Winnifred Brantley",
            "ModifiedDate": "11/15/2000 19:41:57",
            "ModifiedBy": "Grant Ackerman"
        },
    ],
    listEmployee: [{
            "EmployeeId": "57cdf8c4-47e3-5560-7e41-c1ec321fe728",
            "EmployeeCode": "NV-0001",
            "FullName": "Hoàng Thị Linh",
            "DateOfBirth": "1986-08-14T00:00:00",
            "Gender": 1,
            "IdentityNumber": "030300469685",
            "IdentityDate": "2006-08-26T00:00:00",
            "IdentityPlace": "Phú Thọ",
            "PositionName": "Nhân viên",
            "MobilephoneNumber": "0399522451",
            "Address": "Quảng Ngãi",
            "TelephoneNumber": "02804739033",
            "Email": "Ty20030@gmail.com",
            "BankAccountNumber": "1010782738115",
            "BankBranchName": "Quảng Ngãi",
            "BankName": " Đông Á (DongA Bank)",
            "IsSupplier": false,
            "IsCustomer": false,
            "DepartmentId": "11452b0c-768e-5ff7-0d63-eeb1d8ed8cef",
            "CreatedDate": "2020-05-17T00:00:01",
            "CreatedBy": "Bùi Tuyết Linh",
            "ModifiedDate": "2022-01-26T12:51:16",
            "ModifiedBy": "Trần Thị Hà",
            "GenderName": "Nam",
            "DepartmentName": "Phòng Maketing"
        },
        {
            "EmployeeId": "197fda97-5a35-781d-0e77-d9ebc53aac3d",
            "EmployeeCode": "NV-0005",
            "FullName": "Trần Ngọc Nhi",
            "DateOfBirth": "1998-02-27T00:00:00",
            "Gender": 1,
            "IdentityNumber": "030300530474",
            "IdentityDate": "1984-04-01T00:00:00",
            "IdentityPlace": "Hà Giang",
            "PositionName": "Nhân viên",
            "MobilephoneNumber": "0355254228",
            "Address": "TP Hồ Chí Minh",
            "TelephoneNumber": "02950814355",
            "Email": "Thu355@gmail.com",
            "BankAccountNumber": "1010373072796",
            "BankBranchName": "TP Hồ Chí Minh",
            "BankName": " HSBC Việt Nam (HSBC)",
            "IsSupplier": true,
            "IsCustomer": true,
            "DepartmentId": "17120d02-6ab5-3e43-18cb-66948daf6128",
            "CreatedDate": "2020-05-27T00:00:01",
            "CreatedBy": "Nguyễn Phạm Huy",
            "ModifiedDate": "2022-01-11T14:49:03",
            "ModifiedBy": "Nguyễn Bảo Hưng",
            "GenderName": "Nam",
            "DepartmentName": "Phòng Đào tạo"
        },
        {
            "EmployeeId": "4989ff24-23e7-7b82-b6d2-89b22d10517e",
            "EmployeeCode": "NV-0022",
            "FullName": "Nguyễn Thị Thúy",
            "DateOfBirth": "1965-11-20T00:00:00",
            "Gender": 1,
            "IdentityNumber": "030300097133",
            "IdentityDate": "2011-06-27T00:00:00",
            "IdentityPlace": "TP Hồ Chí Minh",
            "PositionName": "Nhân viên",
            "MobilephoneNumber": "0322587427",
            "Address": "Bắc Giang",
            "TelephoneNumber": "02550170068",
            "Email": "Dao382@gmail.com",
            "BankAccountNumber": "1010500269637",
            "BankBranchName": "Bắc Giang",
            "BankName": " Public Bank Việt Nam (PBVN)",
            "IsSupplier": true,
            "IsCustomer": false,
            "DepartmentId": "142cb08f-7c31-21fa-8e90-67245e8b283e",
            "CreatedDate": "2020-07-26T00:00:01",
            "CreatedBy": "Lý Thảo Dung",
            "ModifiedDate": "2022-01-10T02:23:09",
            "ModifiedBy": "Trần Mỹ Như",
            "GenderName": "Nam",
            "DepartmentName": "Phòng nghiên cứu"
        },
        {
            "EmployeeId": "73dc79e1-1ccb-35a6-0235-60b3ebf808a9",
            "EmployeeCode": "NV-0025",
            "FullName": "Huỳnh Hồng Tiến",
            "DateOfBirth": "2001-10-10T00:00:00",
            "Gender": 1,
            "IdentityNumber": "030300772474",
            "IdentityDate": "1987-05-22T00:00:00",
            "IdentityPlace": "Đắk Lắk",
            "PositionName": "Nhân viên",
            "MobilephoneNumber": "0392982753",
            "Address": "Trà Vinh",
            "TelephoneNumber": "02391152395",
            "Email": "Thien12550@gmail.com",
            "BankAccountNumber": "1010095164183",
            "BankBranchName": "Trà Vinh",
            "BankName": " Quốc Tế  (VIB)",
            "IsSupplier": true,
            "IsCustomer": true,
            "DepartmentId": "142cb08f-7c31-21fa-8e90-67245e8b283e",
            "CreatedDate": "2020-07-10T00:00:01",
            "CreatedBy": "Vũ Văn Hoàng",
            "ModifiedDate": "2022-01-09T21:33:43",
            "ModifiedBy": "Võ Thảo Uyên",
            "GenderName": "Nam",
            "DepartmentName": "Phòng nghiên cứu"
        },
        {
            "EmployeeId": "407db4d1-222b-287d-0135-60b3ebf808a9",
            "EmployeeCode": "NV-0020",
            "FullName": "Vũ Mỹ Vân",
            "DateOfBirth": "1984-06-13T00:00:00",
            "Gender": 1,
            "IdentityNumber": "030300589637",
            "IdentityDate": "2008-04-11T00:00:00",
            "IdentityPlace": "Lào Cai",
            "PositionName": "Kế toán",
            "MobilephoneNumber": null,
            "Address": "Hà Nội",
            "TelephoneNumber": "02047106294",
            "Email": "Ban32331@gmail.com",
            "BankAccountNumber": "1010026678052",
            "BankBranchName": "Hà Nội",
            "BankName": " Indovina (IVB)",
            "IsSupplier": true,
            "IsCustomer": true,
            "DepartmentId": "4e272fc4-7875-78d6-7d32-6a1673ffca7c",
            "CreatedDate": "2020-10-15T00:00:01",
            "CreatedBy": "Nguyễn Anh Hoa",
            "ModifiedDate": "2021-12-31T18:30:13",
            "ModifiedBy": "Nguyễn Thị Nga",
            "GenderName": "Nam",
            "DepartmentName": "Phòng Nhân sự"
        },
        {
            "EmployeeId": "56dce332-76f0-6b9b-5080-7ed9d1ea06ea",
            "EmployeeCode": "NV-0016",
            "FullName": "Dương Phan Thành",
            "DateOfBirth": "2001-09-19T00:00:00",
            "Gender": 0,
            "IdentityNumber": "030300630123",
            "IdentityDate": "2005-09-23T00:00:00",
            "IdentityPlace": "Điện Biên",
            "PositionName": "Nhân viên",
            "MobilephoneNumber": "0932685804",
            "Address": "Long An",
            "TelephoneNumber": "02928038012",
            "Email": "Thao399@gmail.com",
            "BankAccountNumber": "1010669351614",
            "BankBranchName": "Long An",
            "BankName": " UOB Việt Nam (UOB)",
            "IsSupplier": true,
            "IsCustomer": false,
            "DepartmentId": "142cb08f-7c31-21fa-8e90-67245e8b283e",
            "CreatedDate": "2020-09-20T00:00:01",
            "CreatedBy": "Nguyễn Thị Anh",
            "ModifiedDate": "2021-12-19T15:27:05",
            "ModifiedBy": "Bùi Thị Thúy",
            "GenderName": "Nữ",
            "DepartmentName": "Phòng nghiên cứu"
        },
        {
            "EmployeeId": "3304dddb-1b72-607f-25c2-579daad24557",
            "EmployeeCode": "NV-0000",
            "FullName": "Lê Thế Hưng",
            "DateOfBirth": "1980-01-16T00:00:00",
            "Gender": 1,
            "IdentityNumber": "030300547499",
            "IdentityDate": "1984-05-11T00:00:00",
            "IdentityPlace": "Hải Dương",
            "PositionName": "Nhân viên",
            "MobilephoneNumber": "0947392495",
            "Address": "Cao Bằng",
            "TelephoneNumber": "02227549424",
            "Email": "Phuoc163@misa.com",
            "BankAccountNumber": "1010571128319",
            "BankBranchName": "Cao Bằng",
            "BankName": " Bản Việt (Viet Capital Bank)",
            "IsSupplier": true,
            "IsCustomer": false,
            "DepartmentId": "17120d02-6ab5-3e43-18cb-66948daf6128",
            "CreatedDate": "2020-10-31T00:00:01",
            "CreatedBy": "Trần Đặng Anh",
            "ModifiedDate": "2021-12-18T09:35:32",
            "ModifiedBy": "Nguyễn Văn Hưng",
            "GenderName": "Nam",
            "DepartmentName": "Phòng Đào tạo"
        },
        {
            "EmployeeId": "62af2231-78a7-7caa-cd1d-086412a8ea97",
            "EmployeeCode": "NV-0014",
            "FullName": "Bùi Văn Vinh",
            "DateOfBirth": "1967-11-16T00:00:00",
            "Gender": 2,
            "IdentityNumber": "030300194929",
            "IdentityDate": "2011-08-27T00:00:00",
            "IdentityPlace": "Trà Vinh",
            "PositionName": "Nhân viên",
            "MobilephoneNumber": "0349464453",
            "Address": "TP Hồ Chí Minh",
            "TelephoneNumber": "02341401648",
            "Email": "Mau574@misa.com",
            "BankAccountNumber": "1010474317825",
            "BankBranchName": "TP Hồ Chí Minh",
            "BankName": " Bảo Việt  (BAOVIET Bank)",
            "IsSupplier": true,
            "IsCustomer": false,
            "DepartmentId": "17120d02-6ab5-3e43-18cb-66948daf6128",
            "CreatedDate": "2020-08-29T00:00:01",
            "CreatedBy": "Phạm Văn Huy",
            "ModifiedDate": "2021-12-18T06:24:06",
            "ModifiedBy": "Nguyễn Trần Hạnh",
            "GenderName": "Khác",
            "DepartmentName": "Phòng Đào tạo"
        },
        {
            "EmployeeId": "2356a2d8-7751-6f97-66f6-423b4e874d0f",
            "EmployeeCode": "NV-0026",
            "FullName": "Nguyễn Phúc Vinh",
            "DateOfBirth": "2001-05-18T00:00:00",
            "Gender": 1,
            "IdentityNumber": "030300358180",
            "IdentityDate": "1976-05-09T00:00:00",
            "IdentityPlace": "An Giang",
            "PositionName": "Nhân viên",
            "MobilephoneNumber": "0874004624",
            "Address": "Vĩnh Phúc",
            "TelephoneNumber": "02364941563",
            "Email": "Mi1887@gmail.com",
            "BankAccountNumber": "1010551261873",
            "BankBranchName": "Vĩnh Phúc",
            "BankName": " Bắc Á (Bac A Bank)",
            "IsSupplier": false,
            "IsCustomer": true,
            "DepartmentId": "142cb08f-7c31-21fa-8e90-67245e8b283e",
            "CreatedDate": "2020-07-12T00:00:01",
            "CreatedBy": "Nguyễn Bảo Huy",
            "ModifiedDate": "2021-12-14T01:20:37",
            "ModifiedBy": "Trần Trần Hiếu",
            "GenderName": "Nam",
            "DepartmentName": "Phòng nghiên cứu"
        },
        {
            "EmployeeId": "7bd9cf39-3f55-3a7b-0035-60b3ebf808a9",
            "EmployeeCode": "NV-0010",
            "FullName": "Trần Thảo Nga",
            "DateOfBirth": "1952-01-07T00:00:00",
            "Gender": 2,
            "IdentityNumber": "030300695997",
            "IdentityDate": "1970-01-07T00:00:00",
            "IdentityPlace": "Bắc Kạn",
            "PositionName": "Thư ký",
            "MobilephoneNumber": "0808007346",
            "Address": "Ninh Bình",
            "TelephoneNumber": "02666856233",
            "Email": "xanh46985@haui.com",
            "BankAccountNumber": "1010696302925",
            "BankBranchName": "Ninh Bình",
            "BankName": " Nam Á (Nam A Bank)",
            "IsSupplier": true,
            "IsCustomer": true,
            "DepartmentId": "4e272fc4-7875-78d6-7d32-6a1673ffca7c",
            "CreatedDate": "2020-06-25T00:00:01",
            "CreatedBy": "Trần Anh Hoàng",
            "ModifiedDate": "2021-12-09T11:46:41",
            "ModifiedBy": "Phạm Văn Tiến",
            "GenderName": "Khác",
            "DepartmentName": "Phòng Nhân sự"
        },
        {
            "EmployeeId": "6c80a684-1cb5-41af-ff34-60b3ebf808a9",
            "EmployeeCode": "NV-0003",
            "FullName": "Vũ Văn Hưng",
            "DateOfBirth": "1992-04-27T00:00:00",
            "Gender": 0,
            "IdentityNumber": "030300614367",
            "IdentityDate": "1998-01-21T00:00:00",
            "IdentityPlace": "Hưng Yên",
            "PositionName": "Kế toán",
            "MobilephoneNumber": "0875406976",
            "Address": "Tiền Giang",
            "TelephoneNumber": "02820804447",
            "Email": "Nhan54984@gmail.com",
            "BankAccountNumber": "1010503858956",
            "BankBranchName": "Tiền Giang",
            "BankName": " Quốc dân (NCB)",
            "IsSupplier": true,
            "IsCustomer": false,
            "DepartmentId": "4e272fc4-7875-78d6-7d32-6a1673ffca7c",
            "CreatedDate": "2021-01-02T00:00:01",
            "CreatedBy": "Trần Thành Phát",
            "ModifiedDate": "2021-11-28T01:29:58",
            "ModifiedBy": "Nguyễn Thảo Nhung",
            "GenderName": "Nữ",
            "DepartmentName": "Phòng Nhân sự"
        },
    ],
    listAccountObjectGroup: [{
            "AccountObjectGroupId": "3f8e6896-4c7d-15f5-a018-75d8bd200d7c",
            "AccountObjectGroupCode": "NCC-1322",
            "AccountObjectGroupName": "Sản xuất tiêu dùng ",
            "CreatedDate": "1970-01-01T02:13:43",
            "CreatedBy": "Norris Calderon",
            "ModifiedDate": "11/24/2014 23:43:46",
            "ModifiedBy": "Elwood Ligon"
        },
        {
            "AccountObjectGroupId": "45ac3d26-18f2-18a9-3031-644313fbb055",
            "AccountObjectGroupCode": "NCC-1351",
            "AccountObjectGroupName": "Dịch vụ",
            "CreatedDate": "1972-09-12T08:14:13",
            "CreatedBy": "Aileen Pitts",
            "ModifiedDate": "09/14/1996 03:31:03",
            "ModifiedBy": "Courtney Abernathy"
        },
        {
            "AccountObjectGroupId": "78aafe4a-67a7-2076-3bf3-eb0223d0a4f7",
            "AccountObjectGroupCode": "NCC-1421",
            "AccountObjectGroupName": "Sản xuất công nghiệp ",
            "CreatedDate": "2008-09-05T16:27:46",
            "CreatedBy": "Trey Christopher",
            "ModifiedDate": "04/20/2004 17:47:05",
            "ModifiedBy": "Natashia Blaylock"
        },
        {
            "AccountObjectGroupId": "7c4f14d8-66fb-14ae-198f-6354f958f4c0",
            "AccountObjectGroupCode": "NCC-5112",
            "AccountObjectGroupName": "Sản xuất nông nghiệp",
            "CreatedDate": "2003-01-23T12:12:00",
            "CreatedBy": "Alaine Hickey",
            "ModifiedDate": "10/08/2010 12:33:26",
            "ModifiedBy": "Rose Aiello"
        },
        {
            "AccountObjectGroupId": "7c4f14d8-66fb-14ae-198f-6354f958f4c0",
            "AccountObjectGroupCode": "NCC-5113",
            "AccountObjectGroupName": "Sản xuất nông nghiệp",
            "CreatedDate": "2003-01-23T12:12:00",
            "CreatedBy": "Alaine Hickey",
            "ModifiedDate": "10/08/2010 12:33:26",
            "ModifiedBy": "Rose Aiello"
        },
        {
            "AccountObjectGroupId": "7c4f14d8-66fb-14ae-198f-6354f958f4c0",
            "AccountObjectGroupCode": "NCC-5114",
            "AccountObjectGroupName": "Sản xuất nông nghiệp",
            "CreatedDate": "2003-01-23T12:12:00",
            "CreatedBy": "Alaine Hickey",
            "ModifiedDate": "10/08/2010 12:33:26",
            "ModifiedBy": "Rose Aiello"
        },
        {
            "AccountObjectGroupId": "7c4f14d8-66fb-14ae-198f-6354f958f4c0",
            "AccountObjectGroupCode": "NCC-5115",
            "AccountObjectGroupName": "Sản xuất nông nghiệp",
            "CreatedDate": "2003-01-23T12:12:00",
            "CreatedBy": "Alaine Hickey",
            "ModifiedDate": "10/08/2010 12:33:26",
            "ModifiedBy": "Rose Aiello"
        }
    ],
    accountTest: {
        "SortIndex": 1,
        "AccountObjectId": "4eceddac-7dc2-38ea-7bdd-867949feb8b5",
        "TaxCode": null,
        "AccountObjectCode": "NCC00065",
        "AccountObjectName": "Công ty BQLUY",
        "Phone": null,
        "Website": "http://tri7998.com",
        "AccountObjectGroupListId": "NCC-1322,NCC-1351",
        "Address": null,
        "Prefix": "Ông",
        "EinvoiceContactName": null,
        "EinvoiceContactMobile": "0884427376",
        "EinvoiceContactEmail": null,
        "LegalRepresentative": "Võ Công Huy",
        "MaximizeDebtAmount": null,
        "DueTime": null,
        "AccountObjectBankAccount": null,
        "AccountObjectShippingAddress": null,
        "Country": null,
        "District": null,
        "WardOrCommune": null,
        "ProvinceOrCity": null,
        "Description": "",
        "CreatedBy": null,
        "CreatedDate": null,
        "ModifiedBy": "Leonardo Lockhart",
        "ModifiedDate": "1999-03-21T04:27:32",
        "PayAccountId": "68daa090-552d-1bc6-e8e4-8adc5263917a",
        "PayAccountCode": "4555",
        "PayAccountName": "Tài khoản công nợ 5",
        "PaymentTermId": "26a546dc-51ef-474e-ec75-f433c80be791",
        "PaymentTermCode": "ĐK113",
        "PaymentTermName": "Điều khoản 3",
        "EmployeeId": "5fab4ff7-1b8e-64d0-1880-de64d090a2c2",
        "EmployeeCode": "NV-0007",
        "FullName": "Trần Thảo Anh"
    }
}

export {
    resourcs,
    misaEnum,
    data,
    dataTest
};