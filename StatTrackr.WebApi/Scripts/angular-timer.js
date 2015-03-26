﻿/**
 * angular-timer - v1.3.1 - 2015-03-13 8:46 AM
 * https://github.com/siddii/angular-timer
 *
 * Copyright (c) 2015 Siddique Hameed
 * Licensed MIT <https://github.com/siddii/angular-timer/blob/master/LICENSE.txt>
 */
var timerModule = angular.module('timer', [])
  .directive('timer', ['$compile', function ($compile) {
      return {
          restrict: 'EA',
          replace: false,
          scope: {
              interval: '=interval',
              startTimeAttr: '=startTime',
              endTimeAttr: '=endTime',
              countdownattr: '=countdown',
              finishCallback: '&finishCallback',
              autoStart: '&autoStart',
              language: '@?',
              maxTimeUnit: '='
          },
          controller: ['$scope', '$element', '$attrs', '$timeout', 'I18nService', '$interpolate', function ($scope, $element, $attrs, $timeout, I18nService, $interpolate) {

              // Checking for trim function since IE8 doesn't have it
              // If not a function, create tirm with RegEx to mimic native trim
              if (typeof String.prototype.trim !== 'function') {
                  String.prototype.trim = function () {
                      return this.replace(/^\s+|\s+$/g, '');
                  };
              }

              //angular 1.2 doesn't support attributes ending in "-start", so we're
              //supporting both "autostart" and "auto-start" as a solution for
              //backward and forward compatibility.
              $scope.autoStart = $attrs.autoStart || $attrs.autostart;


              $scope.language = $scope.language || 'en';

              //allow to change the language of the directive while already launched
              $scope.$watch('language', function () {
                  i18nService.init($scope.language);
              });

              //init momentJS i18n, default english
              var i18nService = new I18nService();
              i18nService.init($scope.language);

              if ($element.html().trim().length === 0) {
                  $element.append($compile('<span>' + $interpolate.startSymbol() + 'millis' + $interpolate.endSymbol() + '</span>')($scope));
              } else {
                  $element.append($compile($element.contents())($scope));
              }

              $scope.startTime = null;
              $scope.endTime = null;
              $scope.timeoutId = null;
              $scope.countdown = $scope.countdownattr && parseInt($scope.countdownattr, 10) >= 0 ? parseInt($scope.countdownattr, 10) : undefined;
              $scope.isRunning = false;

              $scope.$on('timer-start', function () {
                  $scope.start();
              });

              $scope.$on('timer-resume', function () {
                  $scope.resume();
              });

              $scope.$on('timer-stop', function () {
                  $scope.stop();
              });

              $scope.$on('timer-clear', function () {
                  $scope.clear();
              });

              $scope.$on('timer-reset', function () {
                  $scope.reset();
              });

              $scope.$on('timer-set-countdown', function (e, countdown) {
                  $scope.countdown = countdown;
                  $scope.countdownattr = countdown;
                  initValues();
              });

              function resetTimeout() {
                  if ($scope.timeoutId) {
                      clearTimeout($scope.timeoutId);
                  }
              }

              $scope.$watch('startTimeAttr', function (newValue, oldValue) {
                  if (newValue !== oldValue && $scope.isRunning) {
                      $scope.start();
                  }
              });

              $scope.start = $element[0].start = function () {
                  $scope.startTime = $scope.startTimeAttr ? moment($scope.startTimeAttr) : moment();
                  $scope.endTime = $scope.endTimeAttr ? moment($scope.endTimeAttr) : null;
                  if (!$scope.countdown) {
                      $scope.countdown = $scope.countdownattr && parseInt($scope.countdownattr, 10) > 0 ? parseInt($scope.countdownattr, 10) : undefined;
                  }
                  resetTimeout();
                  tick();
                  $scope.isRunning = true;
              };

              $scope.resume = $element[0].resume = function () {
                  resetTimeout();
                  if ($scope.countdownattr) {
                      $scope.countdown += 1;
                  }
                  $scope.startTime = moment().diff((moment($scope.stoppedTime).diff(moment($scope.startTime))));
                  tick();
                  $scope.isRunning = true;
              };

              $scope.stop = $scope.pause = $element[0].stop = $element[0].pause = function () {
                  var timeoutId = $scope.timeoutId;
                  $scope.clear();
                  $scope.$emit('timer-stopped', { timeoutId: timeoutId, millis: $scope.millis, seconds: $scope.seconds, minutes: $scope.minutes, hours: $scope.hours, days: $scope.days });
              };

              $scope.clear = $element[0].clear = function () {
                  // same as stop but without the event being triggered
                  $scope.stoppedTime = moment();
                  resetTimeout();
                  $scope.timeoutId = null;
                  $scope.isRunning = false;
              };

              $scope.reset = $element[0].reset = function () {
                  $scope.startTime = $scope.startTimeAttr ? moment($scope.startTimeAttr) : moment();
                  $scope.endTime = $scope.endTimeAttr ? moment($scope.endTimeAttr) : null;
                  $scope.countdown = $scope.countdownattr && parseInt($scope.countdownattr, 10) > 0 ? parseInt($scope.countdownattr, 10) : undefined;
                  resetTimeout();
                  tick();
                  $scope.isRunning = false;
                  $scope.clear();
              };

              $element.bind('$destroy', function () {
                  resetTimeout();
                  $scope.isRunning = false;
              });


              function calculateTimeUnits() {
                  var timeUnits = {}; //will contains time with units

                  if ($attrs.startTime !== undefined) {
                      $scope.millis = moment().diff(moment($scope.startTimeAttr));
                  }

                  timeUnits = i18nService.getTimeUnits($scope.millis);

                  // compute time values based on maxTimeUnit specification
                  if (!$scope.maxTimeUnit || $scope.maxTimeUnit === 'day') {
                      $scope.seconds = Math.floor(($scope.millis / 1000) % 60);
                      $scope.minutes = Math.floor((($scope.millis / (60000)) % 60));
                      $scope.hours = Math.floor((($scope.millis / (3600000)) % 24));
                      $scope.days = Math.floor((($scope.millis / (3600000)) / 24));
                      $scope.months = 0;
                      $scope.years = 0;
                  } else if ($scope.maxTimeUnit === 'second') {
                      $scope.seconds = Math.floor($scope.millis / 1000);
                      $scope.minutes = 0;
                      $scope.hours = 0;
                      $scope.days = 0;
                      $scope.months = 0;
                      $scope.years = 0;
                  } else if ($scope.maxTimeUnit === 'minute') {
                      $scope.seconds = Math.floor(($scope.millis / 1000) % 60);
                      $scope.minutes = Math.floor($scope.millis / 60000);
                      $scope.hours = 0;
                      $scope.days = 0;
                      $scope.months = 0;
                      $scope.years = 0;
                  } else if ($scope.maxTimeUnit === 'hour') {
                      $scope.seconds = Math.floor(($scope.millis / 1000) % 60);
                      $scope.minutes = Math.floor((($scope.millis / (60000)) % 60));
                      $scope.hours = Math.floor($scope.millis / 3600000);
                      $scope.days = 0;
                      $scope.months = 0;
                      $scope.years = 0;
                  } else if ($scope.maxTimeUnit === 'month') {
                      $scope.seconds = Math.floor(($scope.millis / 1000) % 60);
                      $scope.minutes = Math.floor((($scope.millis / (60000)) % 60));
                      $scope.hours = Math.floor((($scope.millis / (3600000)) % 24));
                      $scope.days = Math.floor((($scope.millis / (3600000)) / 24) % 30);
                      $scope.months = Math.floor((($scope.millis / (3600000)) / 24) / 30);
                      $scope.years = 0;
                  } else if ($scope.maxTimeUnit === 'year') {
                      $scope.seconds = Math.floor(($scope.millis / 1000) % 60);
                      $scope.minutes = Math.floor((($scope.millis / (60000)) % 60));
                      $scope.hours = Math.floor((($scope.millis / (3600000)) % 24));
                      $scope.days = Math.floor((($scope.millis / (3600000)) / 24) % 30);
                      $scope.months = Math.floor((($scope.millis / (3600000)) / 24 / 30) % 12);
                      $scope.years = Math.floor(($scope.millis / (3600000)) / 24 / 365);
                  }
                  // plural - singular unit decision (old syntax, for backwards compatibility and English only, could be deprecated!)
                  $scope.secondsS = ($scope.seconds === 1) ? '' : 's';
                  $scope.minutesS = ($scope.minutes === 1) ? '' : 's';
                  $scope.hoursS = ($scope.hours === 1) ? '' : 's';
                  $scope.daysS = ($scope.days === 1) ? '' : 's';
                  $scope.monthsS = ($scope.months === 1) ? '' : 's';
                  $scope.yearsS = ($scope.years === 1) ? '' : 's';


                  // new plural-singular unit decision functions (for custom units and multilingual support)
                  $scope.secondUnit = timeUnits.seconds;
                  $scope.minuteUnit = timeUnits.minutes;
                  $scope.hourUnit = timeUnits.hours;
                  $scope.dayUnit = timeUnits.days;
                  $scope.monthUnit = timeUnits.months;
                  $scope.yearUnit = timeUnits.years;

                  //add leading zero if number is smaller than 10
                  $scope.sseconds = $scope.seconds < 10 ? '0' + $scope.seconds : $scope.seconds;
                  $scope.mminutes = $scope.minutes < 10 ? '0' + $scope.minutes : $scope.minutes;
                  $scope.hhours = $scope.hours < 10 ? '0' + $scope.hours : $scope.hours;
                  $scope.ddays = $scope.days < 10 ? '0' + $scope.days : $scope.days;
                  $scope.mmonths = $scope.months < 10 ? '0' + $scope.months : $scope.months;
                  $scope.yyears = $scope.years < 10 ? '0' + $scope.years : $scope.years;

              }
              function initValues() {
                  if ($scope.countdownattr) {
                      $scope.millis = $scope.countdownattr * 1000;

                      $scope.addCDSeconds = $element[0].addCDSeconds = function (extraSeconds) {
                          $scope.countdown += extraSeconds;
                          $scope.$digest();
                          if (!$scope.isRunning) {
                              $scope.start();
                          }
                      };

                      $scope.$on('timer-add-cd-seconds', function (e, extraSeconds) {
                          $timeout(function () {
                              $scope.addCDSeconds(extraSeconds);
                          });
                      });

                      $scope.$on('timer-set-countdown-seconds', function (e, countdownSeconds) {
                          if (!$scope.isRunning) {
                              $scope.clear();
                          }

                          $scope.countdown = countdownSeconds;
                          $scope.millis = countdownSeconds * 1000;
                          calculateTimeUnits();
                      });
                  } else {
                      $scope.millis = 0;
                  }
                  calculateTimeUnits();
              }
              //determine initial values of time units and add AddSeconds functionality
              if ($scope.countdownattr) {
                  $scope.millis = $scope.countdownattr * 1000;

                  $scope.addCDSeconds = $element[0].addCDSeconds = function (extraSeconds) {
                      $scope.countdown += extraSeconds;
                      $scope.$digest();
                      if (!$scope.isRunning) {
                          $scope.start();
                      }
                  };

                  $scope.$on('timer-add-cd-seconds', function (e, extraSeconds) {
                      $timeout(function () {
                          $scope.addCDSeconds(extraSeconds);
                      });
                  });

                  $scope.$on('timer-set-countdown-seconds', function (e, countdownSeconds) {
                      if (!$scope.isRunning) {
                          $scope.clear();
                      }

                      $scope.countdown = countdownSeconds;
                      $scope.millis = countdownSeconds * 1000;
                      calculateTimeUnits();
                  });
              } else {
                  $scope.millis = 0;
              }
              calculateTimeUnits();

              var tick = function tick() {

                  $scope.millis = moment().diff($scope.startTime);
                  var adjustment = $scope.millis % 1000;

                  if ($scope.endTimeAttr) {
                      $scope.millis = moment($scope.endTime).diff(moment());
                      adjustment = $scope.interval - $scope.millis % 1000;
                  }

                  if ($scope.countdownattr) {
                      $scope.millis = $scope.countdown * 1000;
                  }

                  if ($scope.millis < 0) {
                      $scope.stop();
                      $scope.millis = 0;
                      calculateTimeUnits();
                      if ($scope.finishCallback) {
                          $scope.$eval($scope.finishCallback);
                      }
                      return;
                  }
                  calculateTimeUnits();

                  //We are not using $timeout for a reason. Please read here - https://github.com/siddii/angular-timer/pull/5
                  $scope.timeoutId = setTimeout(function () {
                      tick();
                      $scope.$digest();
                  }, $scope.interval - adjustment);

                  $scope.$emit('timer-tick', { timeoutId: $scope.timeoutId, millis: $scope.millis });

                  if ($scope.countdown > 0) {
                      $scope.countdown--;
                  }
                  else if ($scope.countdown <= 0) {
                      $scope.stop();
                      if ($scope.finishCallback) {
                          $scope.$eval($scope.finishCallback);
                      }
                  }
              };

              if ($scope.autoStart === undefined || $scope.autoStart === true) {
                  $scope.start();
              }
          }]
      };
  }]);

/* commonjs package manager support (eg componentjs) */
if (typeof module !== "undefined" && typeof exports !== "undefined" && module.exports === exports) {
    module.exports = timerModule;
}

var app = angular.module('timer');

app.factory('I18nService', function () {

    var I18nService = function () { };

    I18nService.prototype.language = 'en';
    I18nService.prototype.timeHumanizer = {};

    I18nService.prototype.init = function init(lang) {
        this.language = lang;
        //moment init
        moment.locale(this.language); //@TODO maybe to remove, it should be handle by the user's application itself, and not inside the directive

        //human duration init, using it because momentjs does not allow accurate time (
        // momentJS: a few moment ago, human duration : 4 seconds ago
        this.timeHumanizer = humanizeDuration.humanizer({
            language: this.language,
            halfUnit: false
        });
    };

    /**
     * get time with units from momentJS i18n
     * @param {int} millis
     * @returns {{millis: string, seconds: string, minutes: string, hours: string, days: string, months: string, years: string}}
     */
    I18nService.prototype.getTimeUnits = function getTimeUnits(millis) {
        var diffFromAlarm = Math.round(millis / 1000) * 1000; //time in milliseconds, get rid of the last 3 ms value to avoid 2.12 seconds display

        var time = {};

        if (typeof this.timeHumanizer != 'undefined') {
            time = {
                'millis': this.timeHumanizer(diffFromAlarm, { units: ["milliseconds"] }),
                'seconds': this.timeHumanizer(diffFromAlarm, { units: ["seconds"] }),
                'minutes': this.timeHumanizer(diffFromAlarm, { units: ["minutes", "seconds"] }),
                'hours': this.timeHumanizer(diffFromAlarm, { units: ["hours", "minutes", "seconds"] }),
                'days': this.timeHumanizer(diffFromAlarm, { units: ["days", "hours", "minutes", "seconds"] }),
                'months': this.timeHumanizer(diffFromAlarm, { units: ["months", "days", "hours", "minutes", "seconds"] }),
                'years': this.timeHumanizer(diffFromAlarm, { units: ["years", "months", "days", "hours", "minutes", "seconds"] })
            };
        }
        else {
            console.error('i18nService has not been initialized. You must call i18nService.init("en") for example');
        }

        return time;
    };

    return I18nService;
});