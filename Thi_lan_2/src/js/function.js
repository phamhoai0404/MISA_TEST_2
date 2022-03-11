import MyFunction2 from "./function2";
var MyFunction = {
    /**
     * Thực hiện định dạng lại ngày
     * CreatedBy: HoaiPT(08/02/2022)
     */
    formatDate: function(value) {
        if (value) {
            value = new Date(value);

            let date = value.getDate();
            date = date < 10 ? `0${date}` : date;

            let month = value.getMonth() + 1;
            month = month < 10 ? `0${month}` : month;

            let year = value.getFullYear();

            value = `${date}/${month}/${year}`;
        } else value = "";

        return value;
    },
    /**
     * Thực hiện tìm kiếm những giá trị trong dãy thỏa mãn dữ kiện đầu vào là và dãy ban đầu là arrayList value
     * .toLowerCase(): Thực hiện chuyển về chữ thường để so sánh cho được nhiều nhất
     * CreatedBy: HoaiPT(28/02/2022)
     */
    selectFilter(arrayList, value) {
        if (value != null) {
            value = value.toLowerCase();
        }
        return arrayList.filter(itemValue => itemValue.toLowerCase().includes(value));
    },
    /**
     * Thực hiện tìm kiếm những giá trị trong dãy thỏa mãn dữ kiện đầu vào là và dãy ban đầu là arrayList ĐỐI TƯỢNG value
     * .toLowerCase(): Thực hiện chuyển về chữ thường để so sánh cho được nhiều nhất
     * CreatedBy: HoaiPT(01/03/2022)
     */
    selectFilterObject(arrayList, nameProperty, value) {
        if (value != null) {
            value = value.toLowerCase();
        }
        let temp = arrayList.filter(itemValue => itemValue[nameProperty].toLowerCase().includes(value));
        return temp;
    },

    /**
     * Thực hiện kiểm tra xem giá trị có tồn tại trong dãy
     * CreatedBy: HoaiPT(28/02/2022)
     */
    existValueInArray(arrayList, value) {
        if (value != null) { //Nếu giá trị tồn tại
            value = value.toLowerCase(); //Thực hiện chuyển value về toàn bộ là chữ thường
            let arrayListTemp = arrayList.filter(itemValue => itemValue.toLowerCase() == value);
            if (arrayListTemp.length > 0)
                return true;
        }
        return false;
    },
    existValueInArray2(arrayList, value) {
        if (value != null) { //Nếu giá trị tồn tại
            let arrayListTemp = arrayList.filter(itemValue => itemValue == value);
            if (arrayListTemp.length > 0)
                return true;
        }
        return false;
    },
    /**
     * Thực hiện kiểm tra xem giá trị có tồn tại trong dãy gồm các đối tượng
     * CreatedBy: HoaiPT(01/03/2022)
     */
    existValueInArrayObject(arrayList, nameProperty, value) {
        if (value != null) { //Nếu giá trị tồn tại
            value = value.toLowerCase(); //Thực hiện chuyển value về toàn bộ là chữ thường
            let arrayListTemp = arrayList.filter(itemValue => itemValue[nameProperty].toLowerCase() == value);
            if (arrayListTemp.length > 0)
                return true;
        }
        return false;
    },
    /**
     * Thực hiện so sánh hai giá trị
     * CreatedBy: HoaiPT(28/02/2022)
     */
    comparisonValue(value1, value2) {
        // console.log("giá trị: ", value1, )
        if (value1 != "" && value2 != "" && value1 != null && value2 != null) {

            // Chuyển hai đối tượng về dạng chữ thường hết
            if (value1.toLowerCase() == value2.toLowerCase()) {
                return true;
            }
        }
        return false;
    },
    /**
     * Thực hiện trả về một đối tượng có giá trị bằng đối tượng truyền vào
     * CreatedBy: HoaiPT(01/03/2022)
     */
    sameObject(objectTarget) {
        let objectTemp = {}; //Tạm thời
        for (var propName in objectTarget) {
            objectTemp[propName] = objectTarget[propName];
        }
        return objectTemp; //Trả về đối tượng muốn lấy mà không dính tới bind
    },
    /**
     * Thực hiện so sánh hai đối tượng có bằng nhau không
     * true: trả về hai đối tượng bằng nhau
     * false: trả về hai đối tượng có giá trị khác nhau
     */
    comparisonObject(object, objectTarget) {
        for (var propName in objectTarget) {
            if (object[propName] != objectTarget[propName]) {
                return false;
            }
        }
        return true;
    },
    /**
     * Thực hiện cắt chuỗi từ có dấu phẩy ngăn cách
     * CreatedBy: HoaiPT(02/03/2022)
     */
    cutStrings(value) {
        if (value) {
            return value.split(",");
        }
        return [];

    },
    /**
     * Thực hiện xóa bỏ một giá trị trong Array
     * CreatedBy: HoaiPT(02/03/2022)
     */
    removeValueInArray(arrayList, value) {
        let arrayListTemp = [];
        if (arrayList) {
            arrayListTemp = arrayList.filter(itemValue => itemValue != value);
        }
        return arrayListTemp;
    },

    /**
     * Thực hiện chuyển từ Json sang Array, 
     * Nếu mà không tồn tại hoặc mảng không có phần tử nào thì mặc định add một rỗng vào
     * CreateBy: HoaiPT(05/03/2022)
     */
    async formatJsonToArray(valueString) {
        let arrayList = [];
        if (valueString == null) {
            arrayList.push({});
        } else {
            arrayList = await JSON.parse(valueString);
            if (arrayList.length == 0) {
                arrayList.push({});
            }
        }
        return arrayList;
    },
    /**
     * Thực chuyển từ Array sang Json 
     * Đồng thời thực hiện xóa bỏ đi đối tượng rỗng hoặc tất cả các giá trị đều ""
     */
    formatArrayToJson(arrayList) {
        arrayList = arrayList.filter(item => MyFunction2.existObject(item));
        let temp = arrayList;
        return JSON.stringify(temp);
    },
    /**
     * Lấy tất cả các đối tượng có giá trị thỏa mãn ở trong trùng với filed có sẵn
     * CreatedBy: HoaiPT(07/03/2022)
     */
    selectFilterObjectInAllField(arraySource, arrayField, value) {
        if (value != null) {
            value = value.toLowerCase();
        }
        let temp = [];
        for (let i = 0; i < arraySource.length; i++) {
            for (let j = 0; j < arrayField.length; j++) {
                let tempValue = arraySource[i][arrayField[j].name];
                if (tempValue != null) {
                    if (tempValue.toLowerCase().includes(value)) {
                        temp.push(arraySource[i]);
                        break;
                    }
                }

            }
        }
        return temp;
    },
    /**
     * Tính tổng các trường
     * CreatedBy: HoaiPT(08/03/2022)
     */
    sumFieldNumber(listData, filed) {
        let sum = 0;
        for (let i = 0; i < listData.length; i++) {
            sum += Number(listData[i][filed]);
        }
        return Number(sum);
    }
}
export default MyFunction