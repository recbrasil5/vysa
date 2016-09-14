(function () {
    "use strict";

    /**
     * Registration Wizard Directives
     *
     * Functions (directives)
     *  - regWizardStepOne
     *  - regWizardStepTwo
     *  - regWizardStepThree
     * 
     */


    /**
     * regWizardStepOne - Directive for Step One
     */
    function regWizardStepOne(registrationDataDeliveryService) {
        return {
            restrict: 'A',
            scope: {
                email: '=',
                password: '=',
                valid: '='
            },
            templateUrl: '../../templates/wizard/registration/step_one.html',
            link: function (scope, el, attr, ctrl) {
                scope.validateEmail = function () {
                    if (scope.email) {
                        //perform check
                        var promise = registrationDataDeliveryService.exists(scope.email);
                        promise.then(function (data) {
                            scope.checked = true;
                            scope.exists = data.exists;
                            console.log(scope.exists)
                        }, function(err) {
                            
                        })
                    }
                    return false; //no dups if not yet valid
                }

                //define if nextBtn is clickable
                scope.isValid = function () {
                    if (!scope.checked) {
                        return false;
                    }
                    scope.valid = scope.exists === false &&
                                  signupForm.password.$error === undefined && signupForm.verify.$error === undefined;
                    console.log(scope.valid);
                    return scope.valid;
                };

            }
        }
    };

    /**
    * regWizardStepTwo - Directive for Step One
    */
    function regWizardStepTwo(registrationDataDeliveryService) {
        return {
            restrict: 'A',
            templateUrl: '../../templates/wizard/registration/step_two.html',
            link: function (scope, el, attr, ctrl) {
            }
        }
    };

    /**
    * regWizardStepThree - Directive for Step One
    */
    function regWizardStepThree(registrationDataDeliveryService) {
        return {
            restrict: 'A',
            templateUrl: '../../templates/wizard/registration/step_three.html',
            link: function (scope, el, attr, ctrl) {
            }
        }
    };

    /***************************************************************************************************************************************/
    /**
     *
     * Pass all functions into module
     */
    angular
        .module('vysaApp')
        .directive('regWizardStepOne', ['registrationDataDeliveryService', regWizardStepOne])
        .directive('regWizardStepTwo', ['registrationDataDeliveryService', regWizardStepTwo])
        .directive('regWizardStepThree', ['registrationDataDeliveryService', regWizardStepThree]);

}());