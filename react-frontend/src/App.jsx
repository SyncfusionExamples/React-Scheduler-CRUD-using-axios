import React, { useEffect, useRef, useState, useCallback } from 'react';
import axios from 'axios';
import {
  ScheduleComponent,
  ViewsDirective,
  ViewDirective,
  Day, Week, WorkWeek, Month, Agenda,
  Inject, Resize, DragAndDrop
} from '@syncfusion/ej2-react-schedule';

const api = axios.create({
  baseURL: 'https://localhost:7268/api',
  timeout: 10000
});

export default function App() {
  const scheduleRef = useRef(null);
  const [events, setEvents] = useState([]);
  const [loading, setLoading] = useState(true);

  // Load initial data
  useEffect(() => {
    let active = true;
    (async () => {
      try {
        const { data } = await api.get('/Schedule');
        if (active) setEvents(data);
      } catch (err) {
        console.error('Failed to load events', err);
      } finally {
        if (active) setLoading(false);
      }
    })();
    return () => { active = false; };
  }, []);

  // Helper to refresh from server
  const refresh = useCallback(async () => {
    const { data } = await api.get('/Schedule');
    setEvents(data);
  }, []);

  // Intercept Scheduler actions
  const onActionBegin = useCallback(async (args) => {
    try {
      if (args.requestType === 'eventCreate') {
        const payload = Array.isArray(args.data) ? args.data[0] : args.data;
        await api.post('/Schedule', payload);
        await refresh();
      }
      else if (args.requestType === 'eventChange') {
        const payload = args.data; // single edited object
        await api.put(`/Schedule/${payload.Id}`, payload);
        await refresh();
      }
      else if (args.requestType === 'eventRemove') {
        const payload = Array.isArray(args.data) ? args.data[0] : args.data;
        await api.delete(`/Schedule/${payload.Id}`);
        await refresh();
      }
    } catch (err) {
      console.error('Scheduler action failed', err);
      // Cancel UI action if needed
      if (args && typeof args.cancel !== 'undefined') args.cancel = true;
    }
  }, [refresh]);

  const eventSettings = {
    dataSource: events,
    fields: {
      id: 'id',
      subject: { name: 'subject' },
      startTime: { name: 'startTime' },
      endTime: { name: 'endTime' },
      isAllDay: { name: 'isAllDay' },
      recurrenceRule: { name: 'recurrenceRule' },
      recurrenceID: { name: 'recurrenceID' },
      recurrenceException: { name: 'recurrenceException' },
      startTimezone: { name: 'startTimezone' },
      endTimezone: { name: 'endTimezone' }
    }
  };

  if (loading) return <div style={{padding:16}}>Loading…</div>;

  return (
    <div style={{ padding: 16 }}>
      <ScheduleComponent
        height="650px"
        ref={scheduleRef}
        currentView="Month"
        selectedDate={new Date()}
        eventSettings={eventSettings}
        actionBegin={onActionBegin}
        allowDragAndDrop={true}
        allowResizing={true}
      >
        <ViewsDirective>
          <ViewDirective option="Day" />
          <ViewDirective option="Week" />
          <ViewDirective option="WorkWeek" />
          <ViewDirective option="Month" />
          <ViewDirective option="Agenda" />
        </ViewsDirective>
        <Inject services={[Day, Week, WorkWeek, Month, Agenda, Resize, DragAndDrop]} />
      </ScheduleComponent>
    </div>
  );
}