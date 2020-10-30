import { check, group, sleep } from "k6";
import http from "k6/http";
const baseUrl = "https://k6loadtesting.azurewebsites.net/";


export let options = {
    stages: [
        {duration: "40s", target: 20},
        {duration: "100s", target: 50},
        {duration: "60s", target: 20},
    ],
    thresholds: {
        "http_req_duration": ["p(90)<400"]
    }
};

export default function() {
    group("machine-page", function() {
        let res = http.get(baseUrl + 'machine');
        check(res, {
            "is status 200": (r) => r.status === 200
        });
        sleep(5);
    });

    group("drink-api", function() {
        let res = http.get(baseUrl + 'api/drink');
        check(res, {
            "is status 200": (r) => r.status === 200
        });
        
        check(res, {
            "is drinks values": (r) => {
                let result = true;
                let data = JSON.parse(r.body);
                
                for (let index = 0; index < data.length; index++) {
                    if(index === 0)
                        result = data[index].DrinkType === 'COFFEE';
                    if(index === 1)
                        result = data[index].DrinkType === 'THE';
                    if(index === 2)
                        result = data[index].DrinkType === 'CAPPUCCINO';
                    if(result === false)               
                        return result;
                }
                return result;
            }
        });
        
        sleep(5);
    });
}