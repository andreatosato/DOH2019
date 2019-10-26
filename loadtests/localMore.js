import { check, group, sleep } from "k6";
import http from "k6/http";
const baseURL = "http://localhost:2355/";

export let options = {
    stages: [
        { duration: "10s", target: 15 },
        { duration: "20s", target: 150 },
        { duration: "10s", target: 250 },
        { duration: "10s", target: 10 }
    ],
    thresholds: {
        "http_req_duration": ["p(95)<250"]
    }
};

export default function() {
    group("API Get Drinks", function() {
        let res = http.get(baseURL + "api/drink");
        check(res, {
            "is status 200": (r) => r.status === 200
        });
        check(res, {
            "has correct data": (r) => JSON.parse(r.body.count) === 3
        });
        sleep(5);
    });

    group("API Get History", function() {
        let res = http.get(baseURL + "api/order");
        check(res, {
            "is status 200": (r) => r.status === 200
        });
        sleep(5);
    });
}