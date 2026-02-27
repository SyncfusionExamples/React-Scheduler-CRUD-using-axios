import { createRoot } from 'react-dom/client';
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
      axios.get('https://localhost:7163/api/Schedule/GetData').then(response => {
        var schObj = document.querySelector('.e-schedule').ej2_instances[0];
        schObj.eventSettings.dataSource = response.data;
      });
      this.flag = false;
    }
  }

  onBegin(args) {
    if (args.requestType === 'eventCreate') {
      axios
        .post('https://localhost:7163/api/Schedule/Insert', args.data[0])
        .then(response => {
          var schObj = document.querySelector('.e-schedule').ej2_instances[0];
          schObj.eventSettings.dataSource = response.data;
        });
    } else if (args.requestType === 'eventChange') {
      axios
        .post('https://localhost:7163/api/Schedule/Update', args.data)
        .then(response => {
          var schObj = document.querySelector('.e-schedule').ej2_instances[0];
          schObj.eventSettings.dataSource = response.data;
        });
    } else if (args.requestType === 'eventRemove') {
      axios
        .post('https://localhost:7163/api/Schedule/Delete', args.data[0])
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
              selectedDate={new Date(2026, 0, 1)}
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
const root = createRoot(document.getElementById('sample'));
root.render(<Default />);