module CommonValues
  very_long_wait = 60
  long_wait = 30
  moderate_wait = 15
  short_wait = 10
  very_short_wait = 5

  long_interval = 1
  moderate_interval = 0.5
  short_interval = 0.3

  def waiting_for_element_timed_out_message(element)
    "Timed out waiting for #{element}"
  end

  def waiting_for_element_to_disappear_timed_out_message(element)
    "Timed out waiting for #{element} to disappear"
  end
end