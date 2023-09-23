
#define PUTCHAR_PROTOTYPE int __io_putchar(int ch)
#define GETCHAR_PROTOTYPE int __io_getchar(void)

#define low 0
#define high 1
#define LOW 0
#define HIGH 1

#define TRUE 1
#define FALSE 0

#define ON 1
#define OFF 0
#define on 1
#define off 0

#define HOLD 0
#define FORWARD 1
#define BACKWARD -1


#define UART_RX_BUF_SIZE 1024
#define UART_TX_BUF_SIZE 1024


#include "main.h"
#include <stdlib.h>
#include <stdio.h>
#include <adc.h>
#include <gpio.h>
#include <math.h>
#include <sysclk.h>
#include <tim.h>
#include <uart.h>
#include <string.h>

extern ADC_HandleTypeDef hadc1;
extern TIM_HandleTypeDef htim2;
extern TIM_HandleTypeDef htim4;

extern UART_HandleTypeDef huart1;
extern UART_HandleTypeDef huart3;



typedef struct  {




	USART_TypeDef *UART;
	uint8_t rxcnt;
	uint8_t txdata;
	uint8_t rxdata;
	char rxbuf[UART_RX_BUF_SIZE];
	char txbuf[UART_TX_BUF_SIZE];

}UART;

UART Uart1 = { 0 };





typedef struct {



	GPIO_PinState state;
	uint8_t cnt;



}SWITCH;




typedef struct {


	TIM_HandleTypeDef* htim;
	uint32_t Channel;
	HAL_TIM_StateTypeDef State;
	uint32_t Step;




}PWM_STATE;



PWM_STATE Pwm1 = { .htim = &htim2,
		.Channel = TIM_CHANNEL_1,
		. State = HAL_TIM_STATE_READY,
		. Step = 0
};

PWM_STATE Pwm2 = { .htim = &htim2,
		.Channel = TIM_CHANNEL_2,
		. State = HAL_TIM_STATE_READY,
		.Step = 0
};


PWM_STATE Pwm3 = { .htim = &htim2,
		.Channel = TIM_CHANNEL_3,
		. State = HAL_TIM_STATE_READY,
		. Step = 0
};


PWM_STATE Pwm4 = { .htim = &htim2,
		. Channel = TIM_CHANNEL_4,
		. State = HAL_TIM_STATE_READY,
		. Step = 0
};





typedef struct {


	PWM_STATE* Pwm;
	int Dir;
	char* Name;
	GPIO_TypeDef* GPIOx;
	uint16_t Pin1;
	uint16_t Pin2;


}MOTOR;






MOTOR Motor1 = { .Pwm = &Pwm1,
		.Dir = HOLD,
		.Name = NULL,
		.GPIOx =  GPIOB,
		.Pin1 = IN6_PIN,
		.Pin2 = IN7_PIN


};


MOTOR Motor2 = { .Pwm = &Pwm2,
		.Dir = HOLD,
		.Name = NULL,
		.GPIOx = GPIOB,
		.Pin1 = IN4_PIN,
		.Pin2 = IN5_PIN


};



MOTOR Motor3 = { .Pwm = &Pwm3,
		.Dir = HOLD,
		.Name = NULL,
		.GPIOx = GPIOA ,
		.Pin1 = IN0_PIN,
		.Pin2 = IN1_PIN

};



MOTOR Motor4 = { .Pwm = &Pwm4,

		.Dir = HOLD,
		.Name = NULL,
		.GPIOx =  GPIOA,
		.Pin1 = IN2_PIN,
		.Pin2 = IN3_PIN


};


/*
MOTOR Motor1 = {.htim = &htim2,
		.Channel = TIM_CHANNEL_1,
		.Pwm =  HAL_TIM_STATE_READY,
		.Dir = HOLD,
		.Name = NULL,
		.GPIOx =  GPIOB,
		.Pin1 = IN6_PIN,
		.Pin2 = IN7_PIN

};



MOTOR Motor2 = { .htim = &htim2,
		.Channel = TIM_CHANNEL_2,
		.Pwm =  HAL_TIM_STATE_READY,
		.Dir = HOLD,
		.Name = NULL,
		.GPIOx = GPIOB,
		.Pin1 = IN4_PIN,
		.Pin2 = IN5_PIN
};

MOTOR Motor3 = {.htim = &htim2,
		.Channel = TIM_CHANNEL_3,
		.Pwm =  HAL_TIM_STATE_READY,
		.Dir = HOLD,
		.Name = NULL,
		.GPIOx = GPIOA ,
		.Pin1 = IN0_PIN,
		.Pin2 = IN1_PIN

};




MOTOR Motor4 = {.htim = &htim2,
		.Channel = TIM_CHANNEL_4,
		.Pwm =  HAL_TIM_STATE_READY,
		.Dir = HOLD,
		.Name = NULL,
		.GPIOx =  GPIOA,
		.Pin1 = IN2_PIN,
		.Pin2 = IN3_PIN
};
 */








SWITCH sw1,sw2,sw3,sw4 = {0};
UART uart1, uart3 = {0};










uint8_t adc_flag = ON;
uint8_t tim4_flag = LOW;

uint8_t PWM_CH1_FLAG = OFF;
uint8_t PWM_CH2_FLAG = OFF;
uint8_t PWM_CH3_FLAG = OFF;
uint8_t PWM_CH4_FLAG = OFF;


uint8_t tim2_flag = LOW;


uint32_t adc_resolution;

uint32_t pwm_resolution;
uint32_t ch1_pwm_resolution;
uint32_t ch2_pwm_resolution;
uint32_t ch3_pwm_resolution;
uint32_t ch4_pwm_resolution;

uint8_t   Dial_Mode_Flag = ON;

uint8_t TIM4_FLAG = ON;



// uint8_t start_flag = low;

char sel;

uint8_t Motor_Power_Flag = OFF;

uint8_t serial_flag = OFF;
uint8_t scroll_flag = ON;










void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart);
void HAL_TIM_OC_DelayElapsedCallback(TIM_HandleTypeDef *htim);
void HAL_TIM_PeriodElapsedCallback(TIM_HandleTypeDef *htim);
void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin);
void Motor_Power ( uint8_t );
void Motor_Dir(  uint8_t );



PUTCHAR_PROTOTYPE
{
	/* Place your implementation of fputc here */
	/* e.g. write a character to the USART2 and Loop until the end of transmission */

	if(serial_flag == ON)
	{
		HAL_UART_Transmit(&huart1, (uint8_t *)&ch, 1, 0xFFFF);
		return ch;

	}

}







int Check_Switch(uint16_t GPIO_Pin)
{



	if(GPIO_Pin == SW1_PIN)
	{
		// switch state low
		sw1.state = HAL_GPIO_ReadPin(SW1_GPIO_PORT,SW1_PIN);


		if( sw1.state == LOW )
		{

			if(sw1.cnt == 0)
			{

				//	 printf("--- SW1 : Pushed ---\n");
				sw1.cnt++;
				// HAL_GPIO_TogglePin(LD1_GPIO_PORT,LD1_PIN);
				return TRUE;


			}

		}


		// check_swtich() = ON;
		else if ( sw1.state == HIGH)
		{

			if(sw1.cnt != 0)
			{
				// printf("--- SW1 : Pulled---\n");
				sw1.cnt = 0;
				return FALSE;
			}




		}
	}



	else if(GPIO_Pin == SW2_PIN)
	{
		// switch state low

		sw2.state = HAL_GPIO_ReadPin(SW2_GPIO_PORT,SW2_PIN);

		if( sw2.state == LOW )
		{

			if(sw2.cnt == 0)
			{

				//	 printf("--- SW2 : Pushed ---\n");
				sw2.cnt++;
				// 	HAL_GPIO_TogglePin(LD2_GPIO_PORT,LD2_PIN);
				return TRUE;



			}

		}


		// check_swtich() = ON;
		else if ( sw2.state == HIGH)
		{

			if(sw2.cnt != 0)
			{
				// printf("--- SW2 : Pulled---\n");
				sw2.cnt = 0;
				return FALSE;
			}




		}
	}



	else if(GPIO_Pin == SW3_PIN)
	{
		// switch state low

		sw3.state = HAL_GPIO_ReadPin(SW3_GPIO_PORT,SW3_PIN);
		if( sw3.state == LOW )
		{

			if(sw3.cnt == 0)
			{

				//	 printf("--- SW3 : Pushed ---\n");
				sw3.cnt++;
				// 	HAL_GPIO_TogglePin(LD3_GPIO_PORT,LD3_PIN);
				return TRUE;



			}

		}


		// check_swtich() = ON;
		else if ( sw3.state == HIGH)
		{

			if(sw3.cnt != 0)
			{
				// printf("--- SW3 : Pulled---\n");
				sw3.cnt = 0;
				return FALSE;
			}




		}
	}



	else if(GPIO_Pin == SW4_PIN)
	{
		// switch state low
		sw4.state = HAL_GPIO_ReadPin(SW4_GPIO_PORT,SW4_PIN);
		if( sw4.state == LOW )
		{

			if(sw4.cnt == 0)
			{

				//	 printf("--- SW4 : Pushed ---\n");
				sw4.cnt++;
				// 	HAL_GPIO_TogglePin(LD4_GPIO_PORT,LD4_PIN);
				return TRUE;



			}

		}


		// check_swtich() = ON;
		else if ( sw4.state == HIGH)
		{

			if(sw4.cnt != 0)
			{
				// printf("--- SW4 : Pulled---\n");
				sw4.cnt = 0;
				return FALSE;
			}




		}
	}





}







//


// Set_Motor(Motor1,ON);
// Set_Motor(Motor2,OFF);
// Check_Motor(Motor1);


//Check Motor .... State , Dir.




int Check_Motor(MOTOR* Motor)
{



	Motor->Pwm->State = TIM_CHANNEL_STATE_GET(&htim2,Motor->Pwm->Channel);

	printf("%s = (%d,%d)\n",Motor -> Name, Motor -> Dir, Motor -> Pwm -> State );


	return Motor->Dir;






}




int Set_Motor(MOTOR* Motor, int Dir)
{





	if(Dir == HOLD)
	{



		HAL_TIM_PWM_Stop(&htim2, Motor->Pwm->Channel);
		Motor-> Pwm->State = TIM_CHANNEL_STATE_GET(&htim2,Motor->Pwm->Channel);
		Motor -> Dir = HOLD;

		HAL_GPIO_WritePin(Motor->GPIOx,Motor->Pin1,0);
		HAL_GPIO_WritePin(Motor->GPIOx,Motor->Pin2,0);


	}

	else if( Dir != HOLD )
	{

		Motor-> Pwm->State = TIM_CHANNEL_STATE_GET(&htim2,Motor->Pwm->Channel);

		if ( Motor -> Pwm->State == HAL_TIM_STATE_READY )
		{

			// Set Motor on
			HAL_TIM_PWM_Start(&htim2 , Motor->Pwm->Channel);
			Motor -> Pwm ->State= HAL_TIM_STATE_BUSY;


			// Set Direction

			if( Dir == FORWARD )
			{





				HAL_GPIO_WritePin(Motor->GPIOx,Motor->Pin1,0);
				HAL_GPIO_WritePin(Motor->GPIOx,Motor->Pin2,1);


				Motor -> Dir = FORWARD;



			}

			else if(Dir == BACKWARD )
			{





				HAL_GPIO_WritePin(Motor->GPIOx,Motor->Pin1,1);
				HAL_GPIO_WritePin(Motor->GPIOx,Motor->Pin2,0);
				Motor -> Dir = BACKWARD;


			}


		}

	}







}



/* USER CODE END 0 */







/* USER CODE BEGIN 1 */
int main(void)
{





	Motor1.Name = "Motor1";
	Motor2.Name = "Motor2";
	Motor3.Name = "Motor3";
	Motor4.Name = "Motor4";



	HAL_Init();

	SystemClock_Config();

	MX_GPIO_Init();


	MX_TIM2_Init( 100  , 1000 , 0 ); // freq = 72*10^6 / 100 * 1000 = 720Hz

	// 32, 100 , 20,000Hz
	// 72 , 1000 , 1,000Hz
	// 144, 1000, 500H




	MX_TIM4_Init(6400,500,1000);
	MX_ADC1_Init();

	HAL_TIM_Base_Start(&htim4);
	HAL_TIM_OC_Start_IT(&htim4, TIM_CHANNEL_1);

	HAL_ADC_Start(&hadc1);
	HAL_ADCEx_Calibration_Start(&hadc1);


	MX_USART1_UART_Init(38400);      /* UART1 : USB TO TTL */
	MX_USART3_UART_Init(38400);      /* UART3 : BLUETOOTH  */


	HAL_UART_Receive_IT(&huart1,(uint8_t*)&uart1.rxdata, 1);
	HAL_UART_Receive_IT(&huart3,(uint8_t*)&uart3.rxdata, 1);

	HAL_TIM_Base_Start(&htim2);


	Set_Motor(&Motor1,HOLD);
	Set_Motor(&Motor2,HOLD);
	Set_Motor(&Motor3,HOLD);
	Set_Motor(&Motor4,HOLD);



	while (1)
	{





	}

}

/* USER CODE END 1 */

/* USER CODE BEGIN 2 */
void HAL_UART_RxCpltCallback(UART_HandleTypeDef *huart)
{

	/* UART1 ---> �ø��� ���  */






	if( huart->Instance == USART1 )
	{

		if(uart1.rxcnt < UART_RX_BUF_SIZE)
		{

			HAL_UART_Receive_IT(&huart1,(uint8_t*)&uart1.rxdata, 1);
			HAL_UART_Transmit(&huart1,(uint8_t*)&uart1.rxdata, 1,0xffff);
			uart1.rxbuf[uart1.rxcnt]  = uart1.rxdata;
			uart1.rxcnt++;

			if(uart1.rxdata == '\n') // ���͸� �Է½�.
			{

				uart1.rxdata = '\0';
				uart1.rxcnt--;
				uart1.rxbuf[uart1.rxcnt] = '\0';


				/*   ������� ������ Ȱ��ȭ
				 *   sprintf(uart3.txbuf,"%s",uart1.rxbuf);
				 *   HAL_UART_Transmit(&huart3,(uint8_t*)uart3.txbuf, strlen(uart3.txbuf),10);
				 */



				printf("Slave : %s\n",uart1.rxbuf);
				if(strcmp(uart1.rxbuf,"ld1") == 0)
				{
					printf("Toggle LD1\n");
					HAL_GPIO_TogglePin(LD1_GPIO_PORT,LD1_PIN);
				}
				else if(strcmp(uart1.rxbuf,"ld2") == 0)
				{
					printf("Toggle LD2\n");
					HAL_GPIO_TogglePin(LD2_GPIO_PORT,LD2_PIN);
				}
				else if(strcmp(uart1.rxbuf,"ld3") == 0)
				{
					printf("Toggle LD3\n");
					HAL_GPIO_TogglePin(LD3_GPIO_PORT,LD3_PIN);
				}
				else if(strcmp(uart1.rxbuf,"ld4") == 0)
				{
					printf("Toggle LD4\n");
					HAL_GPIO_TogglePin(LD4_GPIO_PORT,LD4_PIN);
				}
				else if ( strcmp(uart1.rxbuf,"tim4") == 0 )
				{


					if (TIM4_FLAG == OFF)
					{
						printf("--- TIM4 : ACTIVATED ---\n");
						HAL_TIM_Base_Start(&htim4);
						HAL_TIM_OC_Start_IT(&htim4, TIM_CHANNEL_1);
						TIM4_FLAG = ON;

					}
					else if ( TIM4_FLAG == ON)
					{

						printf("--- TIM4 : INACTIVATED ---\n");
						HAL_TIM_Base_Stop(&htim4);
						HAL_TIM_OC_Stop_IT(&htim4, TIM_CHANNEL_1);
						TIM4_FLAG = OFF;
					}

				}
				else if ( strcmp(uart1.rxbuf,"UART") == 0)
				{

					if(serial_flag == OFF)
					{
						serial_flag = ON;
						printf("--- UART : ACTIVATED ---\n");
					}
					else if (serial_flag == ON)
					{
						printf("--- UART : INACTIVATED ---\n");
						serial_flag = OFF;
					}

				}
				bzero(uart1.rxbuf,sizeof(uart1.rxbuf));

				uart1.rxcnt = 0;

			}
			else if ( uart1.rxdata == '\b')
			{
				uart1.rxdata = '\0';
				HAL_UART_Transmit(&huart1, (uint8_t *)" ", 1, 0xFFFF);
				HAL_UART_Transmit(&huart1, (uint8_t *)"\b", 1, 0xFFFF);
				uart1.rxcnt--;
				uart1.rxbuf[uart1.rxcnt] = '\0';
				uart1.rxcnt--;
				uart1.rxbuf[uart1.rxcnt] = '\0';
			}


		}

		else if (uart1.rxcnt >= UART_RX_BUF_SIZE)
		{


			uart1.rxcnt = 0;
		    bzero(uart1.rxbuf,sizeof(uart1.rxbuf));


		}



	}

	/* UART3 ---> ������� */
	/* PC�κ��� ���ŵ� ������� ������ ó���Ͽ� ���� ���� */
	else if( huart->Instance == USART3 )
	{


		//  uart1.txdata = uart3.rxdata;
		//  HAL_UART_Transmit(&huart1,(uint8_t*)&uart1.txdata, 1,0xffff);








		if(uart3.rxcnt < UART_RX_BUF_SIZE)
		{


			HAL_UART_Receive_IT(&huart3,(uint8_t*)&uart3.rxdata, 1);
			uart3.rxbuf[uart3.rxcnt]  = uart3.rxdata;
			uart3.rxcnt++;

			if(uart3.rxdata == '\n')
			{

				uart3.rxdata = '\0';
				uart3.rxcnt--;
				uart3.rxbuf[uart3.rxcnt] = '\0';

				//	printf("������� : %s\n",uart3.rxbuf);

				if(strcmp(uart3.rxbuf,"Key Mode = ON") == 0) // PC�� ���� Key Mode�� üũ�Ǿ�� �ڵ����� W,A,S,DŰ�� ������.
				{


					printf("Key Mode : ON\n");




				}

				else if(strcmp(uart3.rxbuf,"Key Mode = OFF") == 0)
				{


					printf("Key Mode : OFF\n");

					Set_Motor(&Motor1,HOLD);
					Set_Motor(&Motor2,HOLD);
					Set_Motor(&Motor3,HOLD);
					Set_Motor(&Motor4,HOLD);

					Check_Motor(&Motor1);
					Check_Motor(&Motor2);
					Check_Motor(&Motor3);
					Check_Motor(&Motor4);

				}
				/* Ű������ Q,W,E,A,S,D,Z,X,C��ư���� ���� �ڵ����� �����Ѵ� */
				else if(strcmp(uart3.rxbuf,"W") == 0 ) // Ű���忡�� W������ ����.
				{

					printf("W");
					Set_Motor(&Motor1,FORWARD);
					Set_Motor(&Motor2,FORWARD);
					Set_Motor(&Motor3,FORWARD);
					Set_Motor(&Motor4,FORWARD);

					Check_Motor(&Motor1);
					Check_Motor(&Motor2);
					Check_Motor(&Motor3);
					Check_Motor(&Motor4);


				}
				else if(strcmp(uart3.rxbuf,"S") == 0 ) // Ű���忡�� S������ ����.
				{

					//	  	printf("Motor Direction : HOLD\n");

					printf("S");
					Set_Motor(&Motor1,HOLD);
					Set_Motor(&Motor2,HOLD);

					Set_Motor(&Motor3,HOLD);
					Set_Motor(&Motor4,HOLD);

					Check_Motor(&Motor1);
					Check_Motor(&Motor2);
					Check_Motor(&Motor3);
					Check_Motor(&Motor4);


				}

				else if(strcmp(uart3.rxbuf,"X") == 0 )
				{
					//	  	printf("Motor Direction : BACKWARD\n");


					printf("X");
					Set_Motor(&Motor1,BACKWARD);
					Set_Motor(&Motor2,BACKWARD);

					Set_Motor(&Motor3,BACKWARD);
					Set_Motor(&Motor4,BACKWARD);

					Check_Motor(&Motor1);
					Check_Motor(&Motor2);
					Check_Motor(&Motor3);
					Check_Motor(&Motor4);



				}
				else if(strcmp(uart3.rxbuf,"Q") == 0 )
				{

					printf("Q");
					Set_Motor(&Motor1,FORWARD);
					Set_Motor(&Motor2,FORWARD);

					Set_Motor(&Motor3,HOLD);
					Set_Motor(&Motor4,HOLD);

					Check_Motor(&Motor1);
					Check_Motor(&Motor2);
					Check_Motor(&Motor3);
					Check_Motor(&Motor4);


				}
				else if(strcmp(uart3.rxbuf,"E") == 0 ) // E��ư ������ ���� ����
				{

					printf("E");
					Set_Motor(&Motor1,HOLD);
					Set_Motor(&Motor2,HOLD);

					Set_Motor(&Motor3,FORWARD);
					Set_Motor(&Motor4,FORWARD);

					Check_Motor(&Motor1);
					Check_Motor(&Motor2);
					Check_Motor(&Motor3);
					Check_Motor(&Motor4);


				}
				else if(strcmp(uart3.rxbuf,"Z") == 0 )
				{

					printf("Z");
					Set_Motor(&Motor1,BACKWARD);
					Set_Motor(&Motor2,BACKWARD);

					Set_Motor(&Motor3,HOLD);
					Set_Motor(&Motor4,HOLD);

					Check_Motor(&Motor1);
					Check_Motor(&Motor2);
					Check_Motor(&Motor3);
					Check_Motor(&Motor4);

				}
				else if(strcmp(uart3.rxbuf,"C") == 0 )
				{

					printf("C");
					Set_Motor(&Motor1,HOLD);
					Set_Motor(&Motor2,HOLD);

					Set_Motor(&Motor3,BACKWARD);
					Set_Motor(&Motor4,BACKWARD);

					Check_Motor(&Motor1);
					Check_Motor(&Motor2);
					Check_Motor(&Motor3);
					Check_Motor(&Motor4);


				}
				else if(strcmp(uart3.rxbuf,"Dial Mode = OFF") == 0)
				{



					printf("Switch & Dial : OFF");
					HAL_TIM_OC_Stop_IT(&htim4, TIM_CHANNEL_1);
					Dial_Mode_Flag = OFF;

					Set_Motor(&Motor1,HOLD);
					Set_Motor(&Motor2,HOLD);

					Set_Motor(&Motor3,HOLD);
					Set_Motor(&Motor4,HOLD);

					Check_Motor(&Motor1);
					Check_Motor(&Motor2);
					Check_Motor(&Motor3);
					Check_Motor(&Motor4);


				}
				else if(strcmp(uart3.rxbuf,"Dial Mode = ON") == 0)
				{


					printf("Switch & Dial : ON");
					HAL_TIM_OC_Start_IT(&htim4, TIM_CHANNEL_1);
					Dial_Mode_Flag = ON;

					Set_Motor(&Motor1,HOLD);
					Set_Motor(&Motor2,HOLD);

					Set_Motor(&Motor3,HOLD);
					Set_Motor(&Motor4,HOLD);

					Check_Motor(&Motor1);
					Check_Motor(&Motor2);
					Check_Motor(&Motor3);
					Check_Motor(&Motor4);


				}

				else if ( strcmp(uart3.rxbuf,"LD1") == 0 )
				{

					HAL_GPIO_TogglePin(LD1_GPIO_PORT,LD1_PIN);
					//  printf("--- LD1 : Toggle ---\n");

				}
				else if ( strcmp(uart3.rxbuf,"LD2") == 0 )
				{

					HAL_GPIO_TogglePin(LD2_GPIO_PORT,LD2_PIN);
					//	  printf("--- LD2 : Toggle ---\n");

				}
				else if ( strcmp(uart3.rxbuf,"LD3") == 0 )
				{

					HAL_GPIO_TogglePin(LD3_GPIO_PORT,LD3_PIN);
					//	  printf("--- LD3 : Toggle ---\n");

				}
				else if ( strcmp(uart3.rxbuf,"LD4") == 0 )
				{

					HAL_GPIO_TogglePin(LD4_GPIO_PORT,LD4_PIN);
					//  printf("--- LD4 : Toggle ---\n");

				}
				if(scroll_flag == ON)
				{


					printf("CODE\n");

					if(sel == '1')
					{

						sel = '\0';
						Motor1.Pwm->Step = atoi(uart3.rxbuf);
						analogWrite_ch1(Motor1.Pwm->Step);
						printf("%s PWM STEP : %d\n",Motor1.Name, Motor1.Pwm->Step);

					}

					else if ( sel == '2')
					{

						sel = '\0';
						Motor2.Pwm->Step = atoi(uart3.rxbuf);
						analogWrite_ch2(Motor2.Pwm->Step);
						printf("%s PWM STEP : %d\n",Motor2.Name, Motor2.Pwm->Step);


					}

					else if ( sel == '3')
					{

						sel = '\0';
						Motor3.Pwm->Step = atoi(uart3.rxbuf);
						analogWrite_ch3(Motor3.Pwm->Step);
						printf("%s PWM STEP : %d\n",Motor3.Name, Motor3.Pwm->Step);


					}


					else if ( sel == '4')
					{


						sel = '\0';
						Motor4.Pwm->Step = atoi(uart3.rxbuf);
						analogWrite_ch4(Motor4.Pwm->Step);
						printf("%s PWM STEP : %d\n",Motor4.Name, Motor4.Pwm->Step);

					}

					else if ( sel == '5')
					{

						sel = '\0';
						uint32_t Pwm_Step = atoi(uart3.rxbuf);
						analogWrite(Pwm_Step);
						printf("All Motor PWM STEP : %d\n",Pwm_Step) ;


					}

					scroll_flag = OFF;


				}

				bzero(uart3.rxbuf,sizeof(uart1.rxbuf));

				uart3.rxcnt = 0;

			}

			else if ( uart3.rxdata == '\b')
			{
				uart3.rxdata = '\0';
				HAL_UART_Transmit(&huart1, (uint8_t *)" ", 1, 0xFFFF);
				HAL_UART_Transmit(&huart1, (uint8_t *)"\b", 1, 0xFFFF);
				uart3.rxcnt--;
				uart3.rxbuf[uart3.rxcnt] = '\0';
				uart3.rxcnt--;
				uart3.rxbuf[uart3.rxcnt] = '\0';

			}
			else if( uart3.rxdata == ':') //
			{

				uart3.rxcnt--;
				uart3.rxbuf[uart3.rxcnt] = '\0';
				uart3.rxcnt--;
				sel = uart3.rxbuf[uart3.rxcnt];
				uart3.rxcnt = 0;
				scroll_flag = ON;
			}




		}



	}



}



void HAL_TIM_OC_DelayElapsedCallback(TIM_HandleTypeDef *htim)
{




	if( htim->Instance == TIM4  && htim ->Channel  ==  HAL_TIM_ACTIVE_CHANNEL_1  )
	{


		// adc���� �������� pwm ��Ƽ�� �����Ѵ�.

		HAL_ADC_Start(&hadc1);
		HAL_ADC_PollForConversion(&hadc1, 0xffff);

		adc_resolution  = HAL_ADC_GetValue(&hadc1);

		pwm_resolution =   floor( adc_resolution *  MAX_PWM_RESOLUTION/MAX_ADC_RESOLUTION ); // 0 ~ MAX_PWM_RESOLUTION�� ��Ƽ�� ����.

		analogWrite(pwm_resolution);

		printf("ADC Resolution : %d\n",adc_resolution);
		printf("PWM Resolution : %d\n",pwm_resolution);

		HAL_ADC_Stop(&hadc1);




		Check_Motor(&Motor1);
		Check_Motor(&Motor2);
		Check_Motor(&Motor3);
		Check_Motor(&Motor4);




		if( Check_Switch(SW1_PIN))
		{


			// printf("SW1 : puhsed\n");
			HAL_GPIO_TogglePin(LD1_GPIO_PORT,LD1_PIN);
			if(Check_Motor(&Motor1) == HOLD )
				Set_Motor(&Motor1,FORWARD);



			else Set_Motor(&Motor1,HOLD);


		}
		else if ( !Check_Switch(SW1_PIN)) {} // printf("SW1 : Pulled\n");






		if( Check_Switch(SW2_PIN))
		{


			//printf("SW2 : puhsed\n");
			HAL_GPIO_TogglePin(LD2_GPIO_PORT,LD2_PIN);


			if(Check_Motor(&Motor2) == HOLD )
				Set_Motor(&Motor2,FORWARD);



			else Set_Motor(&Motor2,HOLD);


		}
		else if ( !Check_Switch(SW2_PIN)  ) {} //printf("SW2 : Pulled\n");

		if( Check_Switch(SW3_PIN))
		{


			//	printf("SW3 : puhsed\n");
			HAL_GPIO_TogglePin(LD3_GPIO_PORT,LD3_PIN);


			if(Check_Motor(&Motor3) == HOLD )
				Set_Motor(&Motor3,FORWARD);



			else Set_Motor(&Motor3,HOLD);


		}
		else if ( !Check_Switch(SW3_PIN)) {}//printf("SW3 : Pulled\n");

		if( Check_Switch(SW4_PIN))
		{


			//	printf("SW4 : puhsed\n");
			HAL_GPIO_TogglePin(LD4_GPIO_PORT,LD4_PIN);


			if(Check_Motor(&Motor4) == HOLD )
				Set_Motor(&Motor4,FORWARD);



			else Set_Motor(&Motor4,HOLD);



		}
		else if ( !Check_Switch(SW4_PIN) ){} // printf("SW4 : Pulled\n");




	}



}

void HAL_GPIO_EXTI_Callback(uint16_t GPIO_Pin)
{


	/*
	if(GPIO_Pin == SW1_PIN )
	{

		HAL_GPIO_TogglePin(LD1_GPIO_PORT,LD1_PIN);

		if(Dial_Mode_Flag == ON)
		{

			if(PWM_CH1_Flag == OFF )
			{
				HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_1);
				PWM_CH1_Flag = ON;
			}
			else if ( PWM_CH1_Flag == ON )
			{
				HAL_TIM_PWM_Stop(&htim2, TIM_CHANNEL_1);
				PWM_CH1_Flag = OFF;
			}
		}
	}
	else	if(GPIO_Pin == SW2_PIN )
	{

		HAL_GPIO_TogglePin(LD2_GPIO_PORT,LD2_PIN);
		if(Dial_Mode_Flag == ON)
		{

			if(PWM_CH2_Flag == OFF )
			{
				HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_2);
				PWM_CH2_Flag = ON;
			}
			else if ( PWM_CH2_Flag == ON )
			{
				HAL_TIM_PWM_Stop(&htim2, TIM_CHANNEL_2);
				PWM_CH2_Flag = OFF;
			}
		}

	}
	else	if(GPIO_Pin == SW3_PIN)
	{

		HAL_GPIO_TogglePin(LD3_GPIO_PORT,LD3_PIN);
		if(Dial_Mode_Flag == ON)
		{


			if(PWM_CH3_Flag == OFF )
			{
				HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_3);
				PWM_CH3_Flag = ON;
			}
			else if ( PWM_CH3_Flag == ON )
			{
				HAL_TIM_PWM_Stop(&htim2, TIM_CHANNEL_3);
			 PWM_CH3_Flag = OFF;

			}

		}

	}
	else	if(GPIO_Pin == SW4_PIN)
	{

		HAL_GPIO_TogglePin(LD4_GPIO_PORT,LD4_PIN);
		if(Dial_Mode_Flag == ON)
		{

			if(PWM_CH4_Flag == OFF )
			{
				HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_4);
				PWM_CH4_Flag = ON;
			}
			else if ( PWM_CH4_Flag == ON )
			{
				HAL_TIM_PWM_Stop(&htim2, TIM_CHANNEL_4);
				PWM_CH4_Flag = OFF;
			}
		}

	}
	 */

}
void Motor_Power ( uint8_t state)
{

	switch(state)
	{
	case ON :
	{

		// 	HAL_TIM_Base_Start(&htim2);
		HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_1);
		HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_2);
		HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_3);
		HAL_TIM_PWM_Start(&htim2, TIM_CHANNEL_4);
		Motor_Power_Flag = ON;
		break;

	}
	case OFF :
	{


		//	HAL_TIM_Base_Stop(&htim2);
		HAL_TIM_PWM_Stop(&htim2, TIM_CHANNEL_1);
		HAL_TIM_PWM_Stop(&htim2, TIM_CHANNEL_2);
		HAL_TIM_PWM_Stop(&htim2, TIM_CHANNEL_3);
		HAL_TIM_PWM_Stop(&htim2, TIM_CHANNEL_4);
		Motor_Power_Flag = OFF;
		break;

	}
	}

}
void Motor_Dir(uint8_t dir)
{

	switch(dir)
	{
	case 1 : // forward
	{

		Input0(0); Input1(1);  Input6(0); Input7(1);
		Input2(0); Input3(1);  Input4(0); Input5(1);


		break;
	}
	case 2 :
	{

		Input0(0); Input1(0);  Input6(0); Input7(1);
		Input2(0); Input3(0);  Input4(0); Input5(1);

		break;
	}
	case 3 :
	{
		Input0(0); Input1(0);  Input6(1); Input7(0);
		Input2(0); Input3(0);  Input4(1); Input5(0);

		break;
	}
	case 4 : // backward
	{

		Input0(1); Input1(0);  Input6(1); Input7(0);
		Input2(1); Input3(0);  Input4(1); Input5(0);

		break;
	}
	case 5 :
	{
		Input0(1); Input1(0);  Input6(0); Input7(0);
		Input2(1); Input3(0);  Input4(0); Input5(0);

		break;
	}
	case 6 :
	{
		Input0(0); Input1(1);  Input6(0); Input7(0);
		Input2(0); Input3(1);  Input4(0); Input5(0);

		break;
	}
	case 7 :
	{
		Input0(0); Input1(0);  Input6(0); Input7(0);
		Input2(0); Input3(0);  Input4(0); Input5(0);

		break;
	}
	}



}


/* USER CODE END 2 */


