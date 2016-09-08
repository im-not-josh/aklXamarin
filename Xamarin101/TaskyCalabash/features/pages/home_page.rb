require 'calabash-android'
require_relative '../../features/utilities/common_values'

class HomePage < Calabash::ABase
  include CommonValues
    def trait
      add_task_button
    end

    def add_task
      wait_for_element_exists(add_task_button,
                              {timeout: 5, retry_frequency: 0.3,
                               timeout_message: waiting_for_element_timed_out_message('Add Task Button')})
      touch(add_task_button)
      wait_for_element_does_not_exist(add_task_button,
                                      {timeout: 5, retry_frequency: 0.3,
                                       timeout_message: waiting_for_element_timed_out_message('Add Task Button')})
    end

    def add_task_button
      "AppCompatButton id:'addTaskButton'"
    end
end