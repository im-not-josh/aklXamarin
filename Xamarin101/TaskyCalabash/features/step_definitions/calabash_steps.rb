require 'calabash-android'

Given(/^I am on the home page$/) do
  @current_page = page(HomePage).await(timeout: 30, retry_frequency: 0.3,
                                       timeout_message: 'Timed out waiting for page trait')
end

Given(/^I press the Add Task button$/) do
  @current_page.add_task
  @current_page = page(TaskDetailsPage).await(timeout: 30, retry_frequency: 0.3,
                                              timeout_message: 'Timed out waiting for page trait')
end

Given(/^I should be able to save a new task$/) do
  @current_page.enter_name_and_notes('Xamarin', 'Meetup!')
  @current_page.toggle_done_switch
  @current_page.save_task
  @current_page = page(HomePage).await(timeout: 30, retry_frequency: 0.3,
                                       timeout_message: 'Timed out waiting for page trait')
end