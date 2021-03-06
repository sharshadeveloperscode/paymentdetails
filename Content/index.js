(function($) {

  $.fn.gCalReader = function(options) {
    var $div = $(this);

    var defaults = $.extend({
        calendarId: 'developerscodeteam@gmail.com',
        apiKey: 'AIzaSyC9vh_c4nfuCVn-gl78TkRRlKk1Lopd8qU',
        clientId: '503055486067-sjblj3h1l9olfihgk8io1ur6b4svjh0s.apps.googleusercontent.com',
        dateFormat: 'LongDate',
        errorMsg: 'No events in calendar',
        maxEvents: 50,
     //   futureEventsOnly: true,
        sortDescending: true
      },
      options);
    
    var s = '';
    var feedUrl = 'https://www.googleapis.com/calendar/v3/calendars/' +
      encodeURIComponent(defaults.calendarId.trim()) +'/events?key=' + defaults.apiKey +
      '&orderBy=startTime&singleEvents=true';
      //if(defaults.futureEventsOnly) {
      //  feedUrl+='&timeMin='+ new Date().toISOString();
      //}

      var titlearray = [];
    $.ajax({
      url: feedUrl,
      dataType: 'json',
      success: function (data) {
          console.log(data);
        if(defaults.sortDescending){
          data.items = data.items.reverse();
        }
        data.items = data.items.slice(0, defaults.maxEvents);
        var j = 0;
        var eventData = [];
        $.each(data.items, function (e, item) {
            console.log("e");
            console.log(item);
          var eventdate = item.start.dateTime || item.start.date ||'';
          var summary = item.summary || '';
					var description = item.description;
					var location = item.location;
					s = '<div class="eventtitle">' + summary + '</div>';
					titlearray.push(summary);
					s +='<div class="eventdate"> When: '+ formatDate(eventdate, defaults.dateFormat.trim()) +'</div>';
					if(location) {
						s +='<div class="location">Where: ' + location + '</div>';
					}
					if(description) {
						s +='<div class="description">'+ description +'</div>';
					}
					$($div).append('<li>' + s + '</li>');
					var year = new Date(item.start.dateTime).getFullYear();
					var month = new Date(item.start.dateTime).getMonth();
					var day = new Date(item.start.dateTime).getDate();
						var events = {
						    "start": new Date(year, month, day,new Date(item.start.dateTime).getHours(),new Date(item.start.dateTime).getMinutes()),    //your artist variable
						    "end": new Date(new Date(item.end.dateTime).getFullYear(), new Date(item.end.dateTime).getMonth(), new Date(item.end.dateTime).getDate(), new Date(item.end.dateTime).getHours(), new Date(item.end.dateTime).getMinutes()),   //your title variable
					    "title": titlearray[j]   //your title variable
					};
					j++;
					eventData.push(events);
        });
       

          //create object
       
        //var eventData = {
        //    events: [
        //      { 'id': 1, 'start': new Date(year, month, day, 12), 'end': new Date(year, month, day, 13, 35), 'title': titlearray[0] },
        //      { 'id': 2, 'start': new Date(year, month, day, 14), 'end': new Date(year, month, day, 14, 45), 'title': titlearray[1] },
        //      { 'id': 3, 'start': new Date(year, month, day + 1, 18), 'end': new Date(year, month, day + 1, 18, 45), 'title': titlearray[2] },
        //      { 'id': 4, 'start': new Date(year, month, day - 1, 8), 'end': new Date(year, month, day - 1, 9, 30), 'title': titlearray[0] },
        //      { 'id': 5, 'start': new Date(year, month, day + 1, 14), 'end': new Date(year, month, day + 1, 15), 'title': titlearray[0] }
        //    ]
        //};

        console.log(eventData);
      
        $('#calendar').weekCalendar({
            timeslotsPerHour: 6,
            timeslotHeigh: 30,
            hourLine: true,
            data: eventData,
            height: function ($calendar) {
                return $(window).height() - $('h1').outerHeight(true);
            },
            eventRender: function (calEvent, $event) {
                if (calEvent.end.getTime() < new Date().getTime()) {
                     $event.css('backgroundColor', '#aaa');
                    $event.find('.time').css({ 'backgroundColor': '#999', 'border': '1px solid #888' });
                }
            },
            eventNew: function (calEvent, $event) {
                displayMessage('<strong>Added event</strong><br/>Start: ' + calEvent.start + '<br/>End: ' + calEvent.end);
                alert('You\'ve added a new event. You would capture this event, add the logic for creating a new event with your own fields, data and whatever backend persistence you require.');
             //   var event = gCalReader.getDefaultCalendar().createAllDayEvent('Apollo 11 Landing',
             //   new Date('June 27, 2017'));
                alert("welcome");
                var url = 'https://www.googleapis.com/calendar/v3/calendars/q80se6543bkb40g6fv2hkpburc@group.calendar.google.com/events?sendNotifications=false&access_token=jCWF-Kutav90Xy6sk5PuzmM9';
                var data = {
                    end: { dateTime: '2017-06-27T17:00:00-07:00' },
                    start: {dateTime: '2017-06-27T17:00:00-07:00',
                                   'timeZone': 'Asia/Calcutta'}
                                , summary: "New"
                };
                alert(data);

                var ajax = $.ajax({
                    url: url,
                    contentType: "application/json",
                    data: JSON.stringify(data),
                    method: 'POST',
                    type: 'POST',
                    success:function(d)
                    {
                        alert("success");
                        console.log("success");
                        console.log(d);
                    },
                    error:function(ex)
                    {
                        alert("error");
                        alert(ex.response);
                        console.log(ex.response);
                        console.log("error");
                        console.log(ex);
                    },
                }).done(function (response) {
                    alert("done");
                    console.log(response);
                })
                              .fail(function (jqHXR, textStatus) {
                                  alert("fail");
                                  console.log("addEvent(): ajax failed = " + jqHXR.responseText);
                                  console.log(jqHXR);
                              });

                function addEventDone()
                {
                    alert("hello");
                }
            
            },
            eventDrop: function (calEvent, $event) {
                displayMessage('<strong>Moved Event</strong><br/>Start: ' + calEvent.start + '<br/>End: ' + calEvent.end);
            },
            eventResize: function (calEvent, $event) {
                displayMessage('<strong>Resized Event</strong><br/>Start: ' + calEvent.start + '<br/>End: ' + calEvent.end);
            },
            eventClick: function (calEvent, $event) {
                displayMessage('<strong>Clicked Event</strong><br/>Start: ' + calEvent.start + '<br/>End: ' + calEvent.end);
            },
            eventMouseover: function (calEvent, $event) {
                displayMessage('<strong>Mouseover Event</strong><br/>Start: ' + calEvent.start + '<br/>End: ' + calEvent.end);
            },
            eventMouseout: function (calEvent, $event) {
                displayMessage('<strong>Mouseout Event</strong><br/>Start: ' + calEvent.start + '<br/>End: ' + calEvent.end);
            },
            noEvents: function () {
                displayMessage('There are no events for this week');
            }
        });
      },
      error: function(error) {
        $($div).append('<p>' + defaults.errorMsg + ' | ' + error + '</p>');
      }
    });

    function formatDate(strDate, strFormat) {
      var fd, arrDate, am, time;
      var calendars = {
        months: {
          full: ['', 'January', 'February', 'March', 'April', 'May',
            'June', 'July', 'August', 'September', 'October',
            'November', 'December'
          ],
          short: ['', 'Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul',
            'Aug', 'Sep', 'Oct', 'Nov', 'Dec'
          ]
        },
        days: {
          full: ['Sunday', 'Monday', 'Tuesday', 'Wednesday', 'Thursday',
            'Friday', 'Saturday', 'Sunday'
          ],
          short: ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat',
            'Sun'
          ]
        }
      };

      if (strDate.length > 10) {
        arrDate = /(\d+)\-(\d+)\-(\d+)T(\d+)\:(\d+)/.exec(strDate);

        am = (arrDate[4] < 12);
        time = am ? (parseInt(arrDate[4]) + ':' + arrDate[5] + ' AM') : (
          arrDate[4] - 12 + ':' + arrDate[5] + ' PM');

        if (time.indexOf('0') === 0) {
          if (time.indexOf(':00') === 1) {
            if (time.indexOf('AM') === 5) {
              time = 'MIDNIGHT';
            } else {
              time = 'NOON';
            }
          } else {
            time = time.replace('0:', '12:');
          }
        }

      } else {
        arrDate = /(\d+)\-(\d+)\-(\d+)/.exec(strDate);
        time = 'Time not present in feed.';
      }

      var year = parseInt(arrDate[1]);
      var month = parseInt(arrDate[2]);
      var dayNum = parseInt(arrDate[3]);

      var d = new Date(year, month - 1, dayNum);

      switch (strFormat) {
        case 'ShortTime':
          fd = time;
          break;
        case 'ShortDate':
          fd = month + '/' + dayNum + '/' + year;
          break;
        case 'LongDate':
          fd = calendars.days.full[d.getDay()] + ' ' + calendars.months.full[
            month] + ' ' + dayNum + ', ' + year;
          break;
        case 'LongDate+ShortTime':
          fd = calendars.days.full[d.getDay()] + ' ' + calendars.months.full[
            month] + ' ' + dayNum + ', ' + year + ' ' + time;
          break;
        case 'ShortDate+ShortTime':
          fd = month + '/' + dayNum + '/' + year + ' ' + time;
          break;
        case 'DayMonth':
          fd = calendars.days.short[d.getDay()] + ', ' + calendars.months.full[
            month] + ' ' + dayNum;
          break;
        case 'MonthDay':
          fd = calendars.months.full[month] + ' ' + dayNum;
          break;
        case 'YearMonth':
          fd = calendars.months.full[month] + ' ' + year;
          break;
        default:
          fd = calendars.days.full[d.getDay()] + ' ' + calendars.months.short[
            month] + ' ' + dayNum + ', ' + year + ' ' + time;
      }
      return fd;
    }
  };

  function Call() {
      console.log("teat");
      console.log(localStorage.getItem("ed"));
     
  }
}(jQuery));




//$(document).ready(function () {

    function displayMessage(message) {
        $('#message').html(message).fadeIn();
    }

    $('<div id="message" class="ui-corner-all"></div>').prependTo($('body'));
//});
