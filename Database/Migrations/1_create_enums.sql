CREATE TYPE decision_type AS ENUM ('none', 'default', 'apply', 'deny'); 
CREATE TYPE event_status AS ENUM ('none', 'not_started', 'within_reminder_offset', 'live', 'finished', 'cancelled');
CREATE TYPE event_type AS ENUM ('none', 'personal', 'one_to_one', 'stand_up', 'meeting');
CREATE TYPE group_type AS ENUM ('none', 'educational', 'job');
CREATE TYPE report_type AS ENUM ('none', 'events_report', 'tasks_report');
CREATE TYPE task_current_status AS ENUM ('none', 'to_do', 'in_progress', 'review', 'done');
CREATE TYPE task_type AS ENUM ('none', 'abstract_goal', 'meeting_presense', 'job_complete');

