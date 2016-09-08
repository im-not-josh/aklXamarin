require 'calabash-android'
require_relative '../../features/utilities/common_values'

class TaskDetailsPage < Calabash::ABase
  include CommonValues

    def trait
      save_button
    end

    def enter_name_and_notes(name, notes)
      wait_for_element_exists(name_text_field, {timeout: 5, retry_frequency: 0.3, timeout_message: waiting_for_element_timed_out_message('Name Text Field')})
      enter_text(name_text_field, name)
      enter_text(notes_text_field, notes)
      hide_soft_keyboard
    end

    def toggle_done_switch
      wait_for_element_exists(done_switch, {timeout: 5, retry_frequency: 0.3, timeout_message: waiting_for_element_timed_out_message('Done Switch')})
      touch(done_switch)
    end

    def save_task
      wait_for_element_exists(save_button, {timeout: 5, retry_frequency: 0.3, timeout_message: waiting_for_element_timed_out_message('Add Task Button')})
      touch(save_button)
    end

    def name_text_field
      "AppCompatEditText id:'nameEditText'"
    end

    def notes_text_field
      "AppCompatEditText id:'notesEditText'"
    end

    def done_switch
      "SwitchCompat id:'doneSwitch'"
    end

    def save_button
      "AppCompatButton id:'saveButton'"
    end
end