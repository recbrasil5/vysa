
(function () {
    "use strict";

    angular
        .module("vysaApp")
        .factory('metaDataService', function () {

            var prevArray = [{ _id: 1, someKey: "RINGING", meta: { subKey1: 1234, subKey2: 52 } }];
            var currArray = [{ _id: 1, someKey: "HANGUP", meta: { subKey1: 1234, subKey2: 56 } },
                 { _id: 2, someKey: "RINGING", meta: { subKey1: 5678, subKey2: 207, subKey3: 52 } }];

            return {
                getPrevArray: prevArray,
                getCurrArray: currArray
            }
        });
}());