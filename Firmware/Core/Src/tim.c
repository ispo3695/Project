#include <tim.h>




TIM_HandleTypeDef htim2;
TIM_HandleTypeDef htim4;


void MX_TIM2_Init(uint16_t PSC, uint16_t ARR, uint16_t CCR)
{

	GPIO_InitTypeDef GPIO_InitStruct = {0};

	TIM_OC_InitTypeDef sConfigOC = {0};
	TIM_ClockConfigTypeDef sClockSourceConfig = {0};
	TIM_MasterConfigTypeDef sMasterConfig = {0};

	__HAL_RCC_GPIOA_CLK_ENABLE();
	__HAL_RCC_GPIOB_CLK_ENABLE();

	/**TIM2 GPIO Configuration
	    PA2     ------>  TIM2_CH3  < EN1 >
	    PA3     ------>  TIM2_CH4  < EN0 >
	    PA15     ------> TIM2_CH1  < EN2 >
	    PB3     ------>  TIM2_CH2  < EN3 >
	 */
	GPIO_InitStruct.Pin = EN0_PIN|EN1_PIN|EN2_PIN;
	GPIO_InitStruct.Mode = GPIO_MODE_AF_PP;
	GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
	HAL_GPIO_Init(GPIOA, &GPIO_InitStruct);

	GPIO_InitStruct.Pin = EN3_PIN;
	GPIO_InitStruct.Mode = GPIO_MODE_AF_PP;
	GPIO_InitStruct.Speed = GPIO_SPEED_FREQ_LOW;
	HAL_GPIO_Init(GPIOB, &GPIO_InitStruct);

	__HAL_AFIO_REMAP_TIM2_PARTIAL_1();



	__HAL_RCC_TIM2_CLK_ENABLE();
	/* TIM2 interrupt Init */
	HAL_NVIC_SetPriority(TIM2_IRQn, 0, 0);
	HAL_NVIC_EnableIRQ(TIM2_IRQn);









	htim2.Instance = TIM2;
	htim2.Init.Prescaler = PSC - 1;
	htim2.Init.CounterMode = TIM_COUNTERMODE_UP;
	htim2.Init.Period = ARR - 1;
	htim2.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
	htim2.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_ENABLE;
	HAL_TIM_Base_Init(&htim2);

	sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
	HAL_TIM_ConfigClockSource(&htim2, &sClockSourceConfig);
	HAL_TIM_PWM_Init(&htim2);




	sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
	sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
	HAL_TIMEx_MasterConfigSynchronization(&htim2, &sMasterConfig);



	sConfigOC.OCMode = TIM_OCMODE_PWM2;
	sConfigOC.Pulse = CCR - 1;
	sConfigOC.OCPolarity = TIM_OCPOLARITY_LOW;
	sConfigOC.OCFastMode = TIM_OCFAST_DISABLE;

	HAL_TIM_PWM_ConfigChannel(&htim2, &sConfigOC, TIM_CHANNEL_1);
	HAL_TIM_PWM_ConfigChannel(&htim2, &sConfigOC, TIM_CHANNEL_2);
	HAL_TIM_PWM_ConfigChannel(&htim2, &sConfigOC, TIM_CHANNEL_3);
	HAL_TIM_PWM_ConfigChannel(&htim2, &sConfigOC, TIM_CHANNEL_4);



}





void MX_TIM4_Init(uint16_t PSC, uint16_t CCR, uint16_t ARR)
{



	TIM_ClockConfigTypeDef sClockSourceConfig = {0};
	TIM_MasterConfigTypeDef sMasterConfig = {0};
	TIM_OC_InitTypeDef sConfigOC = {0};


	__HAL_RCC_TIM4_CLK_ENABLE();
	HAL_NVIC_SetPriority(TIM4_IRQn, 0, 0);
	HAL_NVIC_EnableIRQ(TIM4_IRQn);

	htim4.Instance = TIM4;
	htim4.Init.Prescaler = PSC - 1;
	htim4.Init.CounterMode = TIM_COUNTERMODE_UP;
	htim4.Init.Period = ARR - 1;
	htim4.Init.ClockDivision = TIM_CLOCKDIVISION_DIV1;
	htim4.Init.AutoReloadPreload = TIM_AUTORELOAD_PRELOAD_ENABLE;
	HAL_TIM_Base_Init(&htim4);


	sClockSourceConfig.ClockSource = TIM_CLOCKSOURCE_INTERNAL;
	HAL_TIM_ConfigClockSource(&htim4, &sClockSourceConfig);
	HAL_TIM_OC_Init(&htim4);

	sMasterConfig.MasterOutputTrigger = TIM_TRGO_RESET;
	sMasterConfig.MasterSlaveMode = TIM_MASTERSLAVEMODE_DISABLE;
	HAL_TIMEx_MasterConfigSynchronization(&htim4, &sMasterConfig);



	sConfigOC.OCMode = TIM_OCMODE_TIMING;
	sConfigOC.Pulse = CCR - 1;
	sConfigOC.OCPolarity = TIM_OCPOLARITY_HIGH;
	sConfigOC.OCFastMode = TIM_OCFAST_DISABLE;


	HAL_TIM_OC_ConfigChannel(&htim4, &sConfigOC, TIM_CHANNEL_1);





}





void analogWrite(uint16_t pwm_resolution )
{






	uint16_t tim2_arr = TIM2 -> ARR;
	uint16_t  TIM2_CCR =  floor ( ( ( ( tim2_arr ) + 1 )  * pwm_resolution / MAX_PWM_RESOLUTION ) - 1 );



	if( pwm_resolution > MAX_PWM_RESOLUTION ) pwm_resolution = MAX_PWM_RESOLUTION;


	if( pwm_resolution != 0 )
	{


		TIM2 -> CCR1  =  TIM2_CCR;
		TIM2 -> CCR2  =  TIM2_CCR;
		TIM2 -> CCR3  =  TIM2_CCR;
		TIM2 -> CCR4  =  TIM2_CCR;

		//  HAL_TIM_Base_Start(&htim2);

	}
	else if ( pwm_resolution == 0 )
	{

		//  HAL_TIM_Base_Stop(&htim2);

		TIM2 -> CCR1 = 0;
		TIM2 -> CCR2 = 0;
		TIM2 -> CCR3 = 0;
		TIM2 -> CCR4  = 0;

	}








}

void analogWrite_ch1( uint32_t pwm_resolution )
{


	uint32_t tim2_arr = TIM2 -> ARR;
	if( pwm_resolution > MAX_PWM_RESOLUTION ) pwm_resolution = MAX_PWM_RESOLUTION;

	if(pwm_resolution != 0 )
	{


		TIM2 -> CCR1 =   floor ( ( ( ( tim2_arr ) + 1 )  * pwm_resolution / MAX_PWM_RESOLUTION ) - 1 );



	}
	else if ( pwm_resolution == 0 )
	{



		TIM2 -> CCR1 = 0;


	}




}



void analogWrite_ch2( uint32_t pwm_resolution )
{


	uint32_t tim2_arr = TIM2 -> ARR;
	if( pwm_resolution > MAX_PWM_RESOLUTION ) pwm_resolution = MAX_PWM_RESOLUTION;

	if(pwm_resolution != 0 )
	{


		TIM2 -> CCR2 =   floor ( ( ( ( tim2_arr ) + 1 )  * pwm_resolution / MAX_PWM_RESOLUTION ) - 1 );



	}
	else if ( pwm_resolution == 0 )
	{



		TIM2 -> CCR2 = 0;


	}




}

void analogWrite_ch3( uint32_t pwm_resolution )
{


	uint32_t tim2_arr = TIM2 -> ARR;
	if( pwm_resolution > MAX_PWM_RESOLUTION ) pwm_resolution = MAX_PWM_RESOLUTION;

	if(pwm_resolution != 0 )
	{


		TIM2 -> CCR3 =   floor ( ( ( ( tim2_arr ) + 1 )  * pwm_resolution / MAX_PWM_RESOLUTION ) - 1 );



	}
	else if ( pwm_resolution == 0 )
	{



		TIM2 -> CCR3 = 0;


	}




}

void analogWrite_ch4( uint32_t pwm_resolution )
{


	uint32_t tim2_arr = TIM2 -> ARR;
	if( pwm_resolution > MAX_PWM_RESOLUTION ) pwm_resolution = MAX_PWM_RESOLUTION;

	if(pwm_resolution != 0 )
	{


		TIM2 -> CCR4 =   floor ( ( ( ( tim2_arr ) + 1 )  * pwm_resolution / MAX_PWM_RESOLUTION ) - 1 );



	}
	else if ( pwm_resolution == 0 )
	{



		TIM2 -> CCR4 = 0;


	}




}

