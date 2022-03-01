import axios from 'axios'
import * as mylib from './resourcs.js'

var MyFunction = {
    async getListEmployee() {
        try {
            await axios.get('https://localhost:44338/api/v1/Employees')
                .then(function(res) {
                    console.log(res.data);
                    return res.data;
                })
                .catch(function() {
                    return null;
                })
        } catch {
            console.log(mylib.resourcs["VI"].errorMsg);
        }
    }
}
export default MyFunction