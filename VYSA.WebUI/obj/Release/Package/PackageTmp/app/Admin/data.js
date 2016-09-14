(function () {
    "use strict";

var app = angular.module("admin");
app.value('years', [2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025]);
app.value('seasonTypes', ['Spring', 'Summer', 'Fall']);
app.value('relationshipTypes', ['Father', 'Mother', 'StepParent', 'PrimaryGuardian']);
app.value('genderTypes', ['Boy', 'Girl']);

}());{}