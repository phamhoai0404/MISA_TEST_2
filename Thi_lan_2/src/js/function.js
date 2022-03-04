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
        return arrayList.filter(itemValue => itemValue[nameProperty].toLowerCase().includes(value));
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
        // console.log(ho)
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
     * kiểm tra xem có tồn tại đối tượng hay không, đối tượng đó cũng phải khác có tất cả object[prop] =="", chỉ cần object[prop].trim() !="" thì có tồn tại
     * CreateBy: HoaiPT(04/03/2022)
     */
    existObject(object) {
        if (Object.keys(object).length != 0) {
            for (let propName in object) {
                if (object[propName].trim() != "") {
                    return true;
                }
            }
        }
        return false; //Nó không có đối tượng nào cả
    }
}
export default MyFunction