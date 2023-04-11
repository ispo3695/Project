#include <adc.h>



ADC_HandleTypeDef hadc1;

void MX_ADC1_Init(void)
{


  ADC_ChannelConfTypeDef sConfig = {0};
  GPIO_InitTypeDef GPIO_InitStruct = {0};

  __HAL_RCC_ADC1_CLK_ENABLE();
  __HAL_RCC_GPIOA_CLK_ENABLE();


      /**ADC1 GPIO Configuration
      PA6     ------> ADC1_IN6
      */


      GPIO_InitStruct.Pin = GPIO_PIN_6;
      GPIO_InitStruct.Mode = GPIO_MODE_ANALOG;
      HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

      /* ADC1 interrupt Init */
  //    HAL_NVIC_SetPriority(ADC1_2_IRQn, 0, 0);
  //    HAL_NVIC_EnableIRQ(ADC1_2_IRQn);




  hadc1.Instance = ADC1;
  hadc1.Init.ScanConvMode = ADC_SCAN_DISABLE;
  hadc1.Init.ContinuousConvMode = ENABLE;
  hadc1.Init.DiscontinuousConvMode = DISABLE;
  hadc1.Init.ExternalTrigConv = ADC_SOFTWARE_START;
  hadc1.Init.DataAlign = ADC_DATAALIGN_RIGHT;
  hadc1.Init.NbrOfConversion = 1;
  HAL_ADC_Init(&hadc1);

  sConfig.Channel = ADC_CHANNEL_6;
  sConfig.Rank = ADC_REGULAR_RANK_1;
  sConfig.SamplingTime =  ADC_SAMPLETIME_7CYCLES_5;
  HAL_ADC_ConfigChannel(&hadc1, &sConfig);






}


