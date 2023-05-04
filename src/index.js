import { render } from 'react-dom';
import './index.css';
import * as React from 'react';
import { Ajax } from '@syncfusion/ej2-base';
import {
  ScheduleComponent,
  ViewsDirective,
  ViewDirective,
  Day,
  Week,
  WorkWeek,
  Month,
  Agenda,
  Inject,
  Resize,
  DragAndDrop
} from '@syncfusion/ej2-react-schedule';
import { SampleBase } from './sample-base';
import axios from 'axios';
/**
 * Schedule Default sample
 */
export class Default extends SampleBase {
  constructor() {
    super(...arguments);
    this.flag = true;
  }

  onBound(args) {
    if (this.flag) {
      axios.get('http://localhost:54738/Home/GetData').then(response => {
        var schObj = document.querySelector('.e-schedule').ej2_instances[0];
        schObj.eventSettings.dataSource = response.data;
      });
      this.flag = false;
    }
  }

  onBegin(args) {
    if (args.requestType === 'eventCreate') {
      axios
        .post('http://localhost:54738/Home/Insert', args.data[0])
        .then(response => {
          var schObj = document.querySelector('.e-schedule').ej2_instances[0];
          schObj.eventSettings.dataSource = response.data;
        });
    } else if (args.requestType === 'eventChange') {
      axios
        .post('http://localhost:54738/Home/Update', args.data)
        .then(response => {
          var schObj = document.querySelector('.e-schedule').ej2_instances[0];
          schObj.eventSettings.dataSource = response.data;
        });
    } else if (args.requestType === 'eventRemove') {
      axios
        .post('http://localhost:54738/Home/Delete', args.data[0])
        .then(response => {
          var schObj = document.querySelector('.e-schedule').ej2_instances[0];
          schObj.eventSettings.dataSource = response.data;
        });
    }
  }
  render() {
    return (
      <div className="schedule-control-section">
        <div className="col-lg-9 control-section">
          <div className="control-wrapper">
            <ScheduleComponent
              height="650px"
              ref={schedule => (this.scheduleObj = schedule)}
              currentView="Month"
              selectedDate={new Date(2020, 5, 10)}
              dataBound={this.onBound.bind(this)}
              actionBegin={this.onBegin.bind(this)}
            >
              <ViewsDirective>
                <ViewDirective option="Day" />
                <ViewDirective option="Week" />
                <ViewDirective option="WorkWeek" />
                <ViewDirective option="Month" />
                <ViewDirective option="Agenda" />
              </ViewsDirective>
              <Inject
                services={[
                  Day,
                  Week,
                  WorkWeek,
                  Month,
                  Agenda,
                  Resize,
                  DragAndDrop
                ]}
              />
            </ScheduleComponent>
          </div>
        </div>
      </div>
    );
  }
}

render(<Default />, document.getElementById('sample'));
